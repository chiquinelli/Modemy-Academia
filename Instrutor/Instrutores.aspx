<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instrutores.aspx.cs" Inherits="MuscleAcademia.Instrutor.Instrutores" %>

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link rel="shortcut icon" href="./src/imagens/fav-icone.png" type="image/x-icon">

    <title>Document</title>

    <link rel="stylesheet" href="../src/css/styles.css">
    <link rel="stylesheet" href="../src/css/responsive.css">
    <link rel="stylesheet" href="../src/css/reset.css">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@800&family=Poppins:wght@100;300;500&display=swap" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <style>
        /* Estilização geral da tabela */
        .dados-instrutores table {
            border-collapse: collapse;
            width: 100%;
            margin-left: 10%;
            margin-top: 10%;
        }

        /* Estilização dos cabeçalhos da tabela */
        .dados-instrutores th {
            border: 1px solid #ddd;
            font-weight: bold;
            padding: 8px;
            text-align: center;
        }

        /* Estilização das células da tabela */
        .dados-instrutores td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }

        /* Estilização da primeira coluna da tabela (IdInstrutor) */
        /*    .dados-instrutores td:nth-child(1) {
        display: none;
    }*/

        /* Estilização do botão de cadastrar instrutor */
        .btn-cadastro-instrutor {
            background-color: #4CAF50;
            border: none;
            color: white;
            padding: 12px 24px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
        }

        /* Estilização do botão de remover instrutor */
        .btn-remover-instrutor {
            background-color: #f44336;
            border: none;
            color: white;
            padding: 12px 24px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
        }
    </style>
</head>
<body>

    <header class="cabecalho">
        <img src="../src/imagens/perfil.png" alt="">
        <ul>
            <li class="nome-usuario">Nome do usuário</li>
            <li class="nome-academia">Nome academia</li>
        </ul>

        <span class="titulo">Instrutores cadastrados</span>
        <a href="login.html" class="sair">Sair</a>
    </header>

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
        <form id="form1" runat="server">

            <main id="container-instrutores">
                <section class="dados-instrutores">
                    <asp:GridView ID="lstInstrutores" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="IdInstrutor" HeaderText="Id" />
                            <asp:BoundField DataField="NomeCompleto" HeaderText="Nome Completo" />
                            <asp:BoundField DataField="Endereco" HeaderText="Endereco" />
                            <asp:BoundField DataField="NumeroEndereco" HeaderText="Numero" />
                            <asp:BoundField DataField="Cep" HeaderText="CEP" />
                            <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                        </Columns>
                    </asp:GridView>

                    <div class="cadastrar-instrutor">
                        <h3>Quantidade total de instrutores</h3>

                        <p class="quantidade-instrutores">
                            <asp:Literal runat="server" ID="QtdIntrutores"></asp:Literal>
                        </p>
                        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar instrutor(a)" OnClientClick="Cadastrar(event);" CssClass="btn-cadastro-instrutor" />
                        <br>
                        <button class="btn-remover-instrutor">Remover instrutor(a)</button>
                    </div>

                </section>
            </main>
        </form>
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


