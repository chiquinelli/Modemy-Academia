<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MuscleAcademia.Login.login"  %>
<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link rel="shortcut icon" href="../src/imagens/fav-icone.png" type="image/x-icon">

    <title>Modemy - Acesse a nossa plataforma</title>

    <link rel="stylesheet" href="../src/css/styles.css">
    <link rel="stylesheet" href="../src/css/responsive.css">
    <link rel="stylesheet" href="../src/css/reset.css">
    <link rel="stylesheet" href="../src/css/Swal.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../src/js/Swal.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>
</head>
<body>
    <div id="container-login">

        <img class="icone" src="../src/imagens/logo.jpg">

        <form>
            <div>
                <input class="email" type="text" name="email" id="email" placeholder="Digite o seu e-mail">
                <span id="email-error" class="error"></span>
            </div>

            <div>
                <input class="senha" type="password" name="senha" id="senha" placeholder="Digite sua senha">
                <span id="senha-error" class="error"></span>
            </div>


        </form>
        <div>

            <button class="submit" id="btnLogar" onclick="login()"> Login</button>
        </div>

        <div>
            <a class="criar" href="cadastro.html">Não possui acesso? Crie agora</a>
        </div>

    </div>
    <script>
        function login() {
            var email = $("#email").val();
            var senha = $("#senha").val();
            if (VerificarEmail() && VerificarSenha()) {
                $.ajax({
                    type: "POST",
                    url: "Logar.ashx",
                    data: { email: email, senha:senha, method: "Login" },
                    success: function (response) {
                        var resultado = JSON.parse(response);

                        if (resultado.Id != null || resultado.Id != undefined) {
                            Swal.fire({
                                icon: 'success',
                                title: 'O login foi realizado com sucesso!',
                                confirmButton: {
                                    text: 'Ok',
                                    className: 'btn btn-primary'
                                }
                            }).then((result) => {
                                // Executa uma ação após o usuário clicar no botão "Ok"
                                Swal.close();
                                localStorage.setItem("Id", resultado.Id);
                                localStorage.setItem("objUsuario", resultado);
                                window.location.href = '../index.aspx';

                            });
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

            }
        }

        function VerificarEmail() {
            var email = $("#email").val();
            var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

            if (!emailPattern.test(email)) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Por favor, digite um endereço de e-mail válido.',
                    confirmButton: {
                        text: 'Ok',
                        className: 'btn btn-primary'
                    }
                }).then((result) => {
                    // Executa uma ação após o usuário clicar no botão "Ok"
                    Swal.close();
                });
                event.preventDefault();
                return false
            } else {
                return true;
            }
        }
        function VerificarSenha() {
            var senha = $("#senha").val();

            if (senha.length < 6) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Sua senha deve ter pelo menos 6 caracteres.',
                    confirmButton: {
                        text: 'Ok',
                        className: 'btn btn-primary'
                    }
                }).then((result) => {
                    // Executa uma ação após o usuário clicar no botão "Ok"
                    Swal.close();
                });
                event.preventDefault();
                return false
            } else {
                return true;
            }
        }

    </script>

</body>
</html>

