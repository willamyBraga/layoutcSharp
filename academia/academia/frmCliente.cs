using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace academia
{
    public partial class frmCliente : Form
    {
        RegraNegocio.ClientesRegraNegocio novoCliente;
        public frmCliente()
        {
            InitializeComponent();
        }

        //metodo para listar
        private void ListarClientes()
        {
            try
            {
                novoCliente = new RegraNegocio.ClientesRegraNegocio();
                dtgClientes.DataSource = novoCliente.Listar();

                Estilo();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //metodo par adar estilo
        private void Estilo()
        {
            for(int i = 0; i <dtgClientes.Rows.Count; i += 2)
            {
                dtgClientes.Rows[i].DefaultCellStyle.BackColor = Color.Honeydew;
            }
        }
        //metodo limpa campos
        private void Limpar()
        {
            txtRegistro.Text = "0";
            txtNome.Clear();
            txtEndereco.Clear();
            txtObservacoes.Clear();
            txtEstado.Clear();
            txtRG.Clear();
            txttele.Clear();
            txttele2.Clear();
            txtBairro.Clear();
            txtCep.Clear();
            txtCidade.Clear();
            txtCNPJ.Clear();
            txtCPF.Clear();
            txtEI.Clear();
            txtEmail.Clear(); 
         }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbPessFisi_CheckedChanged(object sender, EventArgs e)
        {
            if(rbPessFisi.Checked == true)
            {
                gbDocumentos.Visible = true;
                gbDocumentosJur.Visible = false;
            }
            else
            {
                gbDocumentosJur.Visible = true;
                gbDocumentos.Visible = false;
            }

        }

        private void rbPesJuri_CheckedChanged(object sender, EventArgs e)
        {/*
            if(rbPesJuri.Checked == true)
            {
                gbDocumentosJur.Visible = true;
                gbDocumentos.Visible = false;
            }*/
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                 novoCliente = new RegraNegocio.ClientesRegraNegocio();
            if(txtRegistro.Text == "0")
            {
                if(rbPessFisi.Checked == true)
                {
                    novoCliente.Salvar(txtNome.Text, txtEndereco.Text, txtBairro.Text, txtCep.Text, txtCidade.Text,
                                       txtEstado.Text, txttele.Text, txttele2.Text, txtEmail.Text,
                                       txtdataCadastro.Value.Date, txtNasc.Value.Date, txtObservacoes.Text);

                    DataTable dadosTabela = new DataTable();
                    novoCliente = new RegraNegocio.ClientesRegraNegocio();
                    dadosTabela = novoCliente.Listar();

                    novoCliente = new RegraNegocio.ClientesRegraNegocio();
                    novoCliente.SalvarPessoaFísica(Convert.ToInt32(dadosTabela.Rows[0]["ID_CLIENTE"]), txtCPF.Text, txtRG.Text);
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    novoCliente.Salvar(txtNome.Text, txtEndereco.Text, txtBairro.Text, txtCep.Text, txtCidade.Text,
                                       txtEstado.Text, txttele.Text, txttele2.Text, txtEmail.Text,
                                       txtdataCadastro.Value.Date, txtNasc.Value.Date, txtObservacoes.Text);

                    DataTable dadosTabela = new DataTable();
                    novoCliente = new RegraNegocio.ClientesRegraNegocio();
                    dadosTabela = novoCliente.Listar();

                    novoCliente = new RegraNegocio.ClientesRegraNegocio();
                    novoCliente.SalvarPessoaJuridica(Convert.ToInt32(dadosTabela.Rows[0]["ID_CLIENTE"]), txtEI.Text, txtCNPJ.Text);
                    MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (rbPessFisi.Checked == true) 
                {
                    novoCliente.Alterar(Convert.ToInt32(txtRegistro.Text), txtNome.Text, txtEndereco.Text, txtBairro.Text, txtCep.Text, txtCidade.Text,
                                       txtEstado.Text, txttele.Text, txttele2.Text, txtEmail.Text,
                                       txtdataCadastro.Value.Date, txtNasc.Value.Date, txtObservacoes.Text);

                    novoCliente = new RegraNegocio.ClientesRegraNegocio();
                    novoCliente.AlterarPessoaFisica(Convert.ToInt32(txtRegistro.Text), txtCPF.Text, txtRG.Text);
                    MessageBox.Show("Cliente alterado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    novoCliente.Alterar(Convert.ToInt32(txtRegistro.Text), txtNome.Text, txtEndereco.Text, txtBairro.Text, txtCep.Text,
                                          txtCidade.Text, txtEstado.Text, txttele.Text, txttele2.Text, txtEmail.Text,
                                          txtdataCadastro.Value.Date, txtNasc.Value.Date, txtObservacoes.Text);
                    novoCliente = new RegraNegocio.ClientesRegraNegocio();
                    novoCliente.AlterarPessoaJuridica(Convert.ToInt32(txtRegistro.Text), txtCNPJ.Text, txtEI.Text);
                    MessageBox.Show("Cliente alterado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              }
            ListarClientes();
            Limpar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void dtgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //se sim, verifica se a coluna clicada foi referente ao btnEditar
                if (dtgClientes.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    //preencher o datagrid com os dados da tabela cliente
                    txtRegistro.Text = dtgClientes.Rows[e.RowIndex].Cells["ID_CLIENTE"].Value.ToString();
                    txtNome.Text = dtgClientes.Rows[e.RowIndex].Cells["NOME_CLIENTE"].Value.ToString();
                    txtEndereco.Text = dtgClientes.Rows[e.RowIndex].Cells["ENDERECO_CLIENTE"].Value.ToString();
                    txtBairro.Text = dtgClientes.Rows[e.RowIndex].Cells["BAIRRO_CLIENTE"].Value.ToString();
                    txtCep.Text = dtgClientes.Rows[e.RowIndex].Cells["CEP_CLIENTE"].Value.ToString();
                    txtCidade.Text = dtgClientes.Rows[e.RowIndex].Cells["CIDADE_CLIENTE"].Value.ToString();
                    txtEstado.Text = dtgClientes.Rows[e.RowIndex].Cells["ESTADO_CLIENTE"].Value.ToString();
                    txttele.Text = dtgClientes.Rows[e.RowIndex].Cells["TELEFONE1_CLIENTE"].Value.ToString();
                    txttele2.Text = dtgClientes.Rows[e.RowIndex].Cells["TELEFONE2_CLIENTE"].Value.ToString();
                    txtEmail.Text = dtgClientes.Rows[e.RowIndex].Cells["EMAIL_CLIENTE"].Value.ToString();
                    txtdataCadastro.Value = Convert.ToDateTime(dtgClientes.Rows[e.RowIndex].Cells["DATA_CADASTRO_CLIENTE"].Value.ToString());
                    txtNasc.Value = Convert.ToDateTime(dtgClientes.Rows[e.RowIndex].Cells["NASCIMENTO_CLIENTE"].Value.ToString());
                    txtObservacoes.Text = dtgClientes.Rows[e.RowIndex].Cells["OBSERVACOES_CLIENTE"].Value.ToString();

                   
                    DataTable dadosTabela = new DataTable();
                    novoCliente = new RegraNegocio.ClientesRegraNegocio();
                    dadosTabela = novoCliente.ListarPessoaFisica(Convert.ToInt32(dtgClientes.Rows[e.RowIndex].Cells["ID_CLIENTE"].Value));

                   
                    if (dadosTabela.Rows.Count > 0)
                    {
                     
                        txtCPF.Text = dadosTabela.Rows[0]["CPF_CLIENTE"].ToString();
                        txtRG.Text = dadosTabela.Rows[0]["RG_CLIENTE"].ToString();

                       
                        gbDocumentos.Visible = true;
                        gbDocumentosJur.Visible = false;
                    }
                    else
                    {
                        novoCliente = new RegraNegocio.ClientesRegraNegocio();
                        dadosTabela = novoCliente.ListarPessoaJuridica(Convert.ToInt32(dtgClientes.Rows[e.RowIndex].Cells["ID_CLIENTE"].Value));

                        txtCNPJ.Text = dadosTabela.Rows[0]["CNPJ_CLIENTE"].ToString();
                        txtEI.Text = dadosTabela.Rows[0]["IE_CLIENTE"].ToString();

                        gbDocumentosJur.Visible = true;
                        gbDocumentos.Visible = false;
                    }
                }
                else
                {
                    
                    if (dtgClientes.Columns[e.ColumnIndex].Name == "btnExcluir" &&
                        MessageBox.Show("Deseja realmente excluir?", "Deseja excluir?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            
                            novoCliente = new RegraNegocio.ClientesRegraNegocio();
                            novoCliente.Excluir(Convert.ToInt32(dtgClientes.Rows[e.RowIndex].Cells["ID_CLIENTE"].Value));
                            MessageBox.Show("Cliente excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarClientes();
                            Limpar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbNOME.Checked)
                {
                    dtgClientes.DataSource = novoCliente.PesquisaNome(txtPesquisa.Text);
                }
                else if (rbCPF.Checked)
                {
                    dtgClientes.DataSource = novoCliente.PesquisaCpf(txtPesquisa.Text);
                }
                else if (rdCNPJ.Checked)
                {
                    dtgClientes.DataSource = novoCliente.PesquisaCnpj(txtPesquisa.Text);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
