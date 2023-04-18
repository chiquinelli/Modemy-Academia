<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instrutores.aspx.cs" Inherits="MuscleAcademia.Instrutor.Instrutores" %>

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link rel="shortcut icon" href="../src/imagens/fav-icone.png" type="image/x-icon">

    <title>Document</title>

    <link rel="stylesheet" href="../src/css/instrutoresStyles.css">
    <link rel="stylesheet" href="../src/css/style.css">
    <link rel="stylesheet" href="../src/css/responsive.css">
    <link rel="stylesheet" href="../src/css/reset.css">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@800&family=Poppins:wght@100;300;500&display=swap" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

</head>
<body>

    <header class="cabecalho">
        <div class="cabecalho-itens">
            <img src="../src/imagens/perfil.png" alt="">
            <ul>
                <li class="nome-usuario">
                    <asp:Literal runat="server" ID="nomeUser"></asp:Literal></li>
                <li class="nome-academia">
                    <asp:Literal runat="server" ID="nomeAcademia"></asp:Literal>
                </li>

            </ul>

            <a onclick="Sair()" class="sair">Sair</a>

        </div>
    </header>


    <form id="form1" runat="server">

        <main id="container-instrutores">
            <section class="dados-instrutores">
                <div style="padding: 3rem;">
                    <asp:GridView ID="lstInstrutores" runat="server" AutoGenerateColumns="false" OnRowCommand="lstInstrutores_RowCommand" BorderStyle="None" CellPadding="2" CellSpacing="2" Style="border-collapse: collapse;" OnSelectedIndexChanged="lstInstrutores_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="IdInstrutor" HeaderText="Id" Visible="false" />
                            <asp:BoundField DataField="NomeCompleto" HeaderText="Nome Completo" />
                            <asp:BoundField DataField="Endereco" HeaderText="Endereco" />
                            <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
                            <asp:BoundField DataField="Uf" HeaderText="UF" />
                            <asp:BoundField DataField="NumeroEndereco" HeaderText="Numero" />
                            <asp:BoundField DataField="Cep" HeaderText="CEP" />
                            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Button CssClass="lstEditarBtn" ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("IdInstrutor") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Button CssClass="lstExcluirBtn" ID="btnExcluir" runat="server" Text="Excluir" CommandName="Excluir" CommandArgument='<%# Eval("IdInstrutor") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BorderStyle="None" Font-Overline="False" Font-Strikeout="False" />
                    </asp:GridView>


                </div>
                <div class="cadastrar-instrutor">
                    <h3>Quantidade total de instrutores</h3>

                    <p class="quantidade-instrutores">
                        <asp:Literal runat="server" ID="QtdIntrutores"></asp:Literal>
                    </p>
                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar instrutor(a)" OnClientClick="Cadastrar(event);" CssClass="btn-cadastro-instrutor" />
                    <%--                    <br>
                    <button class="btn-remover-instrutor">Remover instrutor(a)</button>--%>
                </div>

            </section>
        </main>
    </form>
    <footer>
        <nav class="navegacao">
            <ul>
                <li><a href="index.html">Home</a></li>
                <li><a href="matriculas.html">Matrículas</a></li>
                <li><a href="desistencias.html">Desistentes</a></li>
                <li><a href="#">Instrutores</a></li>
                <li><a href="dados.html">Dados</a></li>
            </ul>
        </nav>
    </footer>

</body>
<script>

    //function Cadastrar(event) {
    //    event.preventDefault(); // evita o comportamento padrão do botão

    //    window.location.href = "../cadastro/cadastroInstrutor"; // redireciona para a outra página
    //}
    $("#btnCadastrar").click(() => {
        event.preventDefault();
        window.location.href = "../cadastro/cadastroInstrutor"; // redireciona para a outra página
    });

</script>
</html>


