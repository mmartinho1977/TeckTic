using Pantry.dataaccess;
using Pantry.entities;
using System;
using System.Collections.Generic;
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
            //Sempre que se use uma funcionalidade da página estes métodos sºao evocados
            if (!IsPostBack)
            {
                LoadProdutos();
                LoadCategorias();

                NewProduto();

                txtDescription.Focus(); //para colocar o cursor nesta text quando se abre a página
            }
            

        }

        /// <summary>
        /// Carrega todos os produtos guardados na base de dados para a listbox
        /// </summary>
        protected void LoadProdutos()
        {
            List<Produto> produtos; //lista para guardar os produtos
            ListItem i; //Elemento para construçao de um item para a listbox

            /*
             * Este método vai buscar todos os produtos à base de dados
             * e guarda-os na lista produtos
             */
            produtos = Produtos.SelectAllProdutos();

            //Lipar listBox
            lbxProducts.Items.Clear();

            //Percorrer todos os produtos guardados na lista de produtos e
            //transforma-los em item para guardar na listbox
            foreach (Produto p in produtos)
            {
                i = new ListItem(); //novo item
                i.Text = string.Format("[{0}] {1}", p.Codigo, p.Descricao); //texto que vai aparecer na listBox
                i.Value = p.Codigo.ToString(); //valor que identifica o produto de forma unica entre os restantes

                lbxProducts.Items.Add(i); //Inserir o item acabado de criar na listbox
            }

        }


        /// <summary>
        /// Prepara o formulário para receber um novo produto
        /// </summary>
        protected void NewProduto()
        {
            //O produto ao qual estºao a ser aplicadas as funcionalidades do formulário
            Produto produtoAtual;

            produtoAtual = new Produto(); //novo produto
            produtoAtual.Codigo = -1; //Codigo -1 significa que o produto ainda nºao foi guardado na base de dados
            produtoAtual.Categoria = new Categoria();
            Session["ProdutoAtual"] = produtoAtual; //Esta variável guarda o produto atual entre posts


            //Colocar valores por defeito nas textBoxs
            txtDescription.Text = string.Empty;
            txtPrice.Text = "0.00";
            txtActualQuantity.Text = "0";
            txtMaxQuantity.Text = "0";
            txtMinQuantity.Text = "0";
            txtData.Text = DateTime.Now.ToShortDateString();
            Calendar1.SelectedDate = DateTime.Now;
            drdCategory.ClearSelection(); //nenhuma categoria selecionada
            lbxProducts.ClearSelection();//nenhum produto selecionado

        }



        /// <summary>
        /// Carrega todos as categorias guardados na base de dados para a dropdownList
        /// </summary>
        protected void LoadCategorias()
        {
            List<Categoria> categorias; //lista para guardar as categorias
            ListItem i; //Elemento para construçao de um item para a dropdownList

            //Limpar dropdownlist
            drdCategory.Items.Clear();

            //Por defrito queremos que apareca a palavra selecionar na drop
            i = new ListItem();
            i.Value = "0"; //primeiro da Lista
            i.Text = "Selecionar";

            drdCategory.Items.Add(i);

            /*
             * Este método vai buscar todos as categorias à base de dados
             * e guarda-os na lista categorias
             */
            categorias = Categorias.SelectAllCategorias();

            

            //Percorrer todos as categorias guardados na lista de categorias e
            //transforma-los em item para guardar na dropdown
            foreach (Categoria c in categorias)
            {
                i = new ListItem(); //novo item
                i.Text = string.Format("[{0}] {1}", c.Id, c.Descricao) ; //texto que vai aparecer na dropdown
                i.Value = c.Id.ToString(); //valor que identifica a categoria de forma unica entre os restantes

                drdCategory.Items.Add(i); //Inserir o item acabado de criar na listbox
            }

        }



        /// <summary>
        /// Preenche o formulário com a informaçºao relativa a um produto
        /// </summary>
        protected void WriteProduto()
        {
            Produto produtoAtual = (Produto)Session["ProdutoAtual"]; //produto que está guardado na session

            //preenchimento das txt com o detalhe do produto atual
            txtDescription.Text = produtoAtual.Descricao;
            txtPrice.Text = produtoAtual.Preco.ToString();
            txtMaxQuantity.Text = produtoAtual.QuantidadeMaxima.ToString();
            txtActualQuantity.Text = produtoAtual.QuantidadeAtual.ToString();
            txtMinQuantity.Text = produtoAtual.QuantidadeMinima.ToString();
            drdCategory.SelectedValue = produtoAtual.Categoria.Id.ToString();
            Calendar1.SelectedDate = produtoAtual.DataCompra;
            txtData.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        protected void ReadProduto()
        {
            //Recolha do produto atual guardado na variável session
            Produto produtoAtual = (Produto)Session["ProdutoAtual"];

            //Alteraçºao dos dados do produto atual pelos dados guardados/que constam nas textboxes
            produtoAtual.Descricao = txtDescription.Text;
            produtoAtual.Preco = decimal.Parse(txtPrice.Text.Replace(".",","));
            produtoAtual.QuantidadeAtual = int.Parse(txtActualQuantity.Text);
            produtoAtual.QuantidadeMaxima = int.Parse(txtMaxQuantity.Text);
            produtoAtual.QuantidadeMinima = int.Parse(txtMinQuantity.Text);
            produtoAtual.Categoria.Id = int.Parse(drdCategory.SelectedValue);
            produtoAtual.DataCompra = Calendar1.SelectedDate;

            //Atualizar os dados da variável de sessºao
            Session["ProdutoAtual"] = produtoAtual;

        }


        protected void btbCalendar_Click(object sender, ImageClickEventArgs e)
        {
            //Verficar se o calendário está visível
            if (Calendar1.Visible == true)
            {
                //se estiver visível quando carregamos no botao fica invisível
                Calendar1.Visible = false;
            }
            else
            {
                //caso contrario fica visivel
                Calendar1.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //Escrever a data selecionada da textbox
            txtData.Text = Calendar1.SelectedDate.ToShortDateString();

            //depois de selecionada a data o calendario fica invisivel
            Calendar1.Visible = false;

        }

        protected void lbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produto produtoAtual;
            int codigo;

            codigo = int.Parse(lbxProducts.SelectedItem.Value);

            produtoAtual = Produtos.SelectProdutosByCodigo(codigo);

            //atribuir este produto à variável de sessºao
            Session["ProdutoAtual"] = produtoAtual;

            //Chamar o método WriteProduto para escrever a informaçºao deste produto nas textboxs
            WriteProduto();


        }

        protected void btbNew_Click(object sender, EventArgs e)
        {
            //Limpar as textboxes com  os valores por defeito para um novo produto
            NewProduto();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int res; //guardar o resultado da base de dados
            Produto produtoAtual;

            //Ler os valores das textboxes
            ReadProduto();

            produtoAtual = (Produto)Session["ProdutoAtual"];

            //verificar se algum valor foi selecionado da lista de categorias
            if (drdCategory.SelectedValue == "0")
            {
                //se nºao foi selecionado lança mensagem
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Selecione uma categoria')", true);

                return;//interrompe o método
            }

            //Verificar se o produto atual é novo
            if (produtoAtual.Codigo != -1)
            {
                //Se entrar aqui é porque nºao é novo, logo vai ser editado
                res = Produtos.UpdateProtuto(produtoAtual);
            }
            else
            {
                //se entrar aqui é porque o produto é novo
                res = Produtos.InsertProtuto(produtoAtual);
                //recolher da base de dados o código que lhe foi atribuido
                produtoAtual.Codigo = Produtos.GetProductId();
            }

            //Verificar se a operaçºao foi bem sucedida
            if (res == 1)
            {
                //carregar a list box com o novo produto
                LoadProdutos();
                //Foi bem sucedida
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Produto guardado com sucesso')", true);

            }
            else
            {
                //nºao foi bem sucedida
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Ocorreu um erro')", true);
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int res = 0; //Guardar o resultado da base de dados
            Produto produtoAtual = (Produto)Session["ProdutoAtual"];

            //eliminar o produto somente se ele existir na base de dados - codigo diferente de -1
            if (produtoAtual.Codigo != -1)
            {
                res = Produtos.DeleteProtuto(produtoAtual.Codigo);

                //verificar se a operaçºao foi realizada com sucesso
                if (res == 1)
                {
                    //Atualizar a listbox retirando-lhe o produtp eliminado
                    LoadProdutos();

                    lbxProducts.SelectedValue = null; //sem produtos selecionados na lis

                    //preparar o formulário para novo produto
                    NewProduto();

                    //mensagem
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Produto eliminado com sucesso')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Ocorreu um erro')", true);
                }

            }



        }
    }
}