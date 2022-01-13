using Microsoft.Ajax.Utilities;
using Pantry.dataaccess;
using Pantry.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pantry.web
{
    public partial class ProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Só efetua este passo quando a página é carregada
              Nosrestantes pedidos efetuados ao servidor - PostBack - este passo é ignorado*/
            if (!IsPostBack)
            {

                LoadProdutos(); //carrega os produtos na ListBox de Produtos
                LoadCategorias(); //carrega as categorias na DropdownList de Categorias

                txtDescription.Focus();// Coloca o foco no ccampo descrição quando a página é carregada

                NewProduto();//prepara o formulário para um novo produto
                
            }

        }

        /// <summary>
        /// Carrega todos os produtos da base de dados na ListBox de produtos
        /// </summary>
        protected void LoadProdutos()
        {
            List<Produto> produtos;//lista para carregar os produtos da base de dados
            ListItem i;//Elemento apra construção de cada Item da ListBox
            Produtos.ConnectionString = Application["ConnectionString"].ToString();

            /*O Método SelectAllProducts é responsável por trazer todos os produtos
              guardados na base de dados. Os produtos ficam guardados na Lista de produtos*/
            produtos = Pantry.dataaccess.Produtos.SelectAllProdutos();

            lbxProducts.Items.Clear();//Elimina todos os item existentes na ListBox

            //Para cada produto existente na lista de produtos é criado um Item
            foreach (Produto p in produtos)
            {
                i = new ListItem();//NovoItem
                i.Text = string.Format("[{0}] {1}", p.Codigo, p.Descricao);//Texto a ser mostrado acerca do produto
                i.Value = p.Codigo.ToString();//valor que identifica o produto de forma única

                //adicinar o item criado à ListBox
                lbxProducts.Items.Add(i);

            }
        }

        /// <summary>
        ///  Carrega todas as categorias da base de dados na DropDownList de categorias
        /// </summary>
        protected void LoadCategorias()
        {
            List<Categoria> categorias;//Lista para carregar as categorias da base de dados
            ListItem i;//Elemento para construçºao de item da DropDownList

            Categorias.ConnectionString = Application["ConnectionString"].ToString();

            //Construçºao do Item "Selecionar" - aparece por defeito
            i = new ListItem();
            i.Value = "0";
            i.Text = "Selecionar";

            drdCategoria.Items.Add(i);//Addicionar o item à drodownlist

            /*O Método SelectAllCategorias é responsável por trazer todas as categorias
              guardados na base de dados. As categorias ficam guardados na Lista de categorias*/
            categorias = Pantry.dataaccess.Categorias.SelectAllCategorias();

            ///Para cada categoria existente na lista de categorias é criado um Item
            foreach (Categoria c in categorias)
            {
                i = new ListItem();//Novo item
                i.Text = string.Format("[{0}] {1}", c.Id, c.Descricao);//Texto a ser mostrado acerca da categoria
                i.Value = c.Id.ToString();//valor que identifica a categoria de forma única

                //adicionar o item criado à dropdownlist
                drdCategoria.Items.Add(i);
            }
        }

        /// <summary>
        /// Prepara o formulário para preenchimento de um novo produto
        /// </summary>
        protected void NewProduto()
        {
            /*Produto atual, o produto cujo detalhe é mostrado nos campos
             do formulário do lado esquerdo*/
            Produto produtoAtual;

            produtoAtual = new Produto(); //Novo produto
            produtoAtual.Codigo = -1;//Codigo -1 significa que o produto nºao foi guardado na base de dados
            produtoAtual.Categoria = new Categoria();//nova categoria de produto
            Session["ProdutoAtual"] = produtoAtual;//Criar uma variável global para aceder ao produto de todo o lado

            txtDescription.Text = string.Empty; // descricao a vazio
            txtPrice.Text = "0.00"; // preço a zero
            txtQuantidadeAtual.Text = "0"; //quantidade atual a zero
            txtQuantidadeMinima.Text = "0"; //quantidade Minima a zero
            txtQuantidadeMaxima.Text = "0"; // quantidade máxima a zero
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy"); //Atribuir a data de hoje;
            Calendar1.SelectedDate = DateTime.Now;
            drdCategoria.ClearSelection();//limpar a seleção da dropdownlist de categorias
            lbxProducts.ClearSelection();// limpar a seleçao la listBox de produtos
        }

        /// <summary>
        /// Atualiza um produto com os valores existentes da textbox do formulário
        /// </summary>
        protected void ReadProduto()
        {
            //Recolha do produto guardado na variável de sessºao
            Produto produtoAtual = (Produto)Session["ProdutoAtual"];

            //Alteração dos dados do produto guardados das textbox respetivas
            produtoAtual.Descricao = txtDescription.Text;
            produtoAtual.Preco = decimal.Parse(txtPrice.Text.Replace(".",","));
            produtoAtual.QuantidadeAtual = int.Parse(txtQuantidadeAtual.Text);
            produtoAtual.QuantidadeMinima = int.Parse(txtQuantidadeMinima.Text);
            produtoAtual.QuantidadeMaxima = int.Parse(txtQuantidadeMaxima.Text);
            produtoAtual.Categoria.Id = int.Parse(drdCategoria.SelectedValue);
            produtoAtual.DataCompra = Calendar1.SelectedDate;

            //atribuir o produto alterado à variável de sessção
            Session["ProdutoAtual"] = produtoAtual;
        }
         
        /// <summary>
        /// Preenche os campos do formulário com os detalhes do produto atual
        /// </summary>
        protected void WriteProduto()
        {
            //produto atual é igual ao produto guardado na variável de sessao
            Produto produtoAtual = (Produto)Session["ProdutoAtual"]; 

            //preencimento dos campos com o detalhe do produto
            txtDescription.Text = produtoAtual.Descricao;
            txtPrice.Text = produtoAtual.Preco.ToString();
            txtQuantidadeAtual.Text = produtoAtual.QuantidadeAtual.ToString();
            txtQuantidadeMinima.Text = produtoAtual.QuantidadeMinima.ToString();
            txtQuantidadeMaxima.Text = produtoAtual.QuantidadeMaxima.ToString();
            drdCategoria.SelectedValue = produtoAtual.Categoria.Id.ToString();
            Calendar1.SelectedDate = produtoAtual.DataCompra;
            txtDate.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        }


        protected void btnNew_Click(object sender, EventArgs e)
        {
            //Preparar o formulário para criaçao de um novo produto
            NewProduto();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int res; //variável para resultado da query 1 se eliminou com sucesso, 0 caso contrário
            Produto produtoAtual; //Produto atual

            Produtos.ConnectionString = Application["ConnectionString"].ToString();

            //ler informaçao do produto inserida nos respetivos campos 
            ReadProduto();

            //atribuir o valor a variável de sesssao ao produto atual
            produtoAtual = (Produto)Session["ProdutoAtual"];

            if (drdCategoria.SelectedValue=="0")
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Selecione uma categoria');", true);
                return;
            }
            
            //Verificar se o produto é para inserir ou para atualizar - -1 significa que nunca foi guardado na base de dados
            if (produtoAtual.Codigo != -1)
            {
                //se codigo for diferente de -1 atualiza o produto
                res = Produtos.UpdateProtuto(produtoAtual);
            }
            else
            {
                //Se codigo for igual a -1 insere o produto na base de dados
                res = Produtos.InsertProtuto(produtoAtual);

                //Vai buscar à base de dados o código atribuído ao novo produto
                produtoAtual.Codigo = Produtos.GetProductId();
            }

            //verificar se a operaçºao foi realizada com sucesso
            if (res == 1)
            {
                //Atualizar a lista de produtos, com o novo produto
                LoadProdutos();

                //Selecionar na ListBox o novo produto a partir do seu código
                lbxProducts.SelectedValue = produtoAtual.Codigo.ToString();

                //Mostrar mensagem ao utilizador;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Operação realizada com sucesso');", true);
            }
            else
            {
                //caso o produto nao tenha sido guardado lançar mensagem de erro
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Ocorreu um erro inesperado');", true);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int res = 0; //variável para resultado da query 1 se eliminou com sucesso, 0 caso contrário
            Produto produtoAtual = (Produto)Session["ProdutoAtual"];//Produto atual é carregado com os valores da variável de sessão
            Produtos.ConnectionString = Application["ConnectionString"].ToString();

            //verificar se o produto é existe na base de dados, se codigo -1 é porque ainda nºao foi guardado
            if (produtoAtual.Codigo != -1)
            {
                //se o seu código é -1 significa que é novo.

                //apagar o produto dabase de dados
                res = Produtos.DeleteProtuto(produtoAtual.Codigo);

                //verificar se a operaçºao anterior foi realizada ou nºao
                if (res == 1)
                {
                    //SelectedDatesCollection o resultado for 1 significa que o produto for eliminado

                    //Atualizar a lista de produtos, sem o produto elimidado
                    LoadProdutos();

                    //Retirar a seleçºao de produtos da listboz
                    lbxProducts.SelectedValue = null;

                    //prepara o formulário para criaçºao de um novo produto
                    NewProduto();

                    //Mostrar mensagem ao utilizador;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Operação realizada com sucesso');", true);
                }
                else
                {
                    //caso o produto nºao tenha sido eliminado lançar mensagem de erro
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Ocorreu um erro inesperado');", true);
                }
            }
        }

        protected void btnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            //verificar se o calendário está visível
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;// se visível esconde-o
            }
            else
            {
                Calendar1.Visible = true;//se invisível mostra-o
            }
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //escrever a data selecionada na textbox
            txtDate.Text = Calendar1.SelectedDate.ToShortDateString();
            //Esconder o calendário
            Calendar1.Visible = false;
        }

        protected void lbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produto produtoAtual;//novo produto

            int codigo = int.Parse(lbxProducts.SelectedItem.Value);//recolher o código único do produto

            //Selecionar o produto na base de dados
            produtoAtual = Produtos.SelectProdutosByCodigo(codigo);

            //atribuir à variável de sesssºao o produto selecionado
            Session["ProdutoAtual"] = produtoAtual;

            //escrever os detalhes do produto selecionado nos respetivos campos
            WriteProduto();
        }


        
    }
}