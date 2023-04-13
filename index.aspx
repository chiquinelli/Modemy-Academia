<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MuscleAcademia.index"%>

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link rel="shortcut icon" href="./src/imagens/fav-icone.png" type="image/x-icon">

    <title>Modemy - sua academia moderna</title>

    <link rel="stylesheet" href="src/css/styles.css">
    <link rel="stylesheet" href="src/css/responsive.css">
    <link rel="stylesheet" href="src/css/reset.css">

    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@800&family=Poppins:wght@100;300;500&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="src/css/Swal.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="./src/js/Swal.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>

</head>
<body>
    <header class="cabecalho">
        <div class="cabecalho-itens">
            <img src="src/imagens/perfil.png" alt="">
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

    <main id="area-conteudo">

        <section class="campos">
            <a href="matriculas.html">
                <h4>MATRÍCULAS</h4>
                <asp:Literal runat="server" ID="QtdMatriculas"></asp:Literal>
            </a>
        </section>

        <section class="campos">
            <a href="desistencias.html">
                <h4>DESISTÊNCIAS</h4>
                <asp:Literal runat="server" ID="QtdDesistencias"></asp:Literal>
            </a>
        </section>

        <section class="campos">
            <a href="Instrutor/instrutores">
                <h4>INSTRUTORES</h4>
                <asp:Literal runat="server" ID="QtdIntrutores"></asp:Literal>
            </a>
        </section>

        <section class="campos">
            <a href="dados.html">
                <h4>DADOS DE FREQUÊNCIA</h4>
            </a>
        </section>
    </main>

    <!--</div>-->
    <footer id="rodape">
        <p>© Modemy - 2022</p>
    </footer>

    <script>
        $(document).ready(function () {
            var Id = localStorage.getItem("Id");
            $.ajax({
                type: "POST",
                url: "Login/Logar.ashx",
                data: { Id: Id, method: "ResgatarLogin" },
                success: function (response) {
                    var resultado = JSON.parse(response);

                    if (resultado.Id != null || resultado.Id != undefined) {
                        $(".nome-usuario").html(resultado.Nome);
                        $(".nome-academia").html(resultado.Instituicao);

                    } else {
                        // código para executar quando o login for inválido
                        console.log("Login inválido");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    // código para executar quando ocorrer um erro na chamada Ajax
                    console.log("Ocorreu um erro: " + errorThrown);
                }
            });

        });

        function Sair() {
            $.ajax({
                type: "POST",
                url: "Login/Logar.ashx",
                data: { method: "Sair" },
                success: function (response) {
                    var resultado = JSON.parse(response);

                    if (resultado.status != null) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Você foi deslogado com sucesso!',
                            confirmButton: {
                                text: 'Ok',
                                className: 'btn btn-primary'
                            }
                        }).then((result) => {
                            // Executa uma ação após o usuário clicar no botão "Ok"
                            Swal.close();
                            window.location.href = 'Login/login.aspx';

                        });
                    } else {
                        // código para executar quando o login for inválido
                        console.log("Erro ao deslogar.");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    // código para executar quando ocorrer um erro na chamada Ajax
                    console.log("Ocorreu um erro: " + errorThrown);
                }
            });

        }
            </script>
</body>

</html>
