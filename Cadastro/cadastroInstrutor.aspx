<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastroInstrutor.aspx.cs" Inherits="MuscleAcademia.Cadastro.cadastroInstrutor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link rel="shortcut icon" href="../src/imagens/fav-icone.png" type="image/x-icon">

    <title>Modemy - Cadastre-se na nossa plataforma</title>

    <link rel="stylesheet" href="../src/css/cadastroInstrutor-css.css">
    <link rel="stylesheet" href="../src/css/responsive.css">
    <link rel="stylesheet" href="../src/css/reset.css">
    <link rel="stylesheet" href="../src/css/Swal.css">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@800&family=Poppins:wght@100;300;500&display=swap" rel="stylesheet">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../src/js/Swal.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>

</head>
<body>
    <div class="formInstrutor">

        <img src="../src/imagens/logo.jpg" alt="">

        <form id="form1">

            <div class="prr">
                <div class="divName">
                    <label for="nome">Nome do instrutor(a)</label>
                    <input class="nome campoInstrutor" type="text" name="nome" id="nome" runat="server">
                </div>

                <div class="divTelefone">
                    <label for="telefone">Telefone</label>
                    <br>
                    <input class="telefone campoInstrutor" type="text" name="telefone" id="telefone" runat="server">
                </div>

                <div class="divCep">
                    <label for="cep">CEP</label>
                    <input class="cep campoInstrutor" type="text" name="cep" id="cep" runat="server">
                </div>

                <div class="divEndereco">
                    <label for="endereco">Endereço</label>
                    <input class="endereco campoInstrutor" type="text" name="endereco" id="endereco" runat="server">
                </div>

                <div class="divNumero">
                    <label for="numero">Nº</label>
                    <input class="numero campoInstrutor" type="text" name="numero" id="numero" runat="server">
                </div>


            </div>
        </form>
                        <input class="submit" type="submit" value="Cadastrar" onclick="Cadastrar()">
                <input class="cancel" type="submit" value="Cancelar" onclick="Voltar()">
    </div>
    <script>
        $(document).ready(function () {

            $("#telefone").mask('(00) 00000-0000');
            $("#cep").mask('00000-000');
            const buscaCep = $('#cep');

            buscaCep.on('blur', function () {
                // Chama a função quando o campo perder o foco
                BuscarCep();
            });


        });

        var nome;
        var telefone;
        var cep;
        var endereco;
        var numero;
        function BuscarCep() {
            cep = $("#cep").val();
            const url = `https://viacep.com.br/ws/${cep}/json/`;

            fetch(url)
                .then(response => response.json())
                .then(data => {
                    if (data.erro) {
                        // Se o CEP não foi encontrado, exibe uma mensagem de erro
                        console.log('CEP não encontrado.');
                    } else {
                        // Se o CEP foi encontrado, preenche os campos do endereço
                        document.getElementById('endereco').value = data.logradouro;
                        //document.getElementById('bairro').value = data.bairro;
                        //document.getElementById('cidade').value = data.localidade;
                        //document.getElementById('estado').value = data.uf;

                    }
                })
                .catch(error => {
                    console.log('CEP inválido:');
                });        }
        function ValidarCampos() {
            // Selecionando os campos
            nome = $("#nome").val();
            telefone = $("#telefone").val();
            cep = $("#cep").val();
            numero = $("#numero").val();
            endereco = $("#endereco").val();

            // Verifica se os campos não estão vazios
            if (nome === "" || telefone === "" || cep === "" || endereco === "" || numero === "") {
                Swal.fire({
                    icon: 'warning',
                    title: 'Por favor, preencha todos os campos.',
                    confirmButton: {
                        text: 'Ok',
                        className: 'btn btn-primary'
                    }
                }).then((result) => {
                    // Executa uma ação após o usuário clicar no botão "Ok"
                    Swal.close();
                });
                return false;
            }
            if (cep.lenght < 8) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Por favor colque um cep valido',
                    confirmButton: {
                        text: 'Ok',
                        className: 'btn btn-primary'
                    }
                }).then((result) => {
                    // Executa uma ação após o usuário clicar no botão "Ok"
                    Swal.close();
                    cep.focus();
                });
                return false;
            }

            cep = cep.replace(/[-]/g, '');
            telefone = telefone.replace(/[()-\s]/g, '');


            // Se todas as validações passarem, retorna true
            return true;

        }
        function Voltar() {
            window.location.href = '../index';

        }
        function Cadastrar() {
            if (ValidarCampos()) {
                $.ajax({
                    type: "POST",
                    url: "Cadastro.ashx/Cadastrar",
                    data: { nome: nome, telefone: telefone, cep: cep, endereco: endereco, numero: numero, method: "CadastrarInstrutor" },
                    success: function (response) {
                        var resultado = JSON.parse(response);

                        if (resultado.status === "success") {
                            Swal.fire({
                                icon: 'success',
                                title: 'O cadastro foi salvo com sucesso!',
                                confirmButton: {
                                    text: 'Ok',
                                    className: 'btn btn-primary'
                                }
                            }).then((result) => {
                                // Executa uma ação após o usuário clicar no botão "Ok"
                                Swal.close();
                                location.reload();
                            });
                        } else {
                            Swal.fire({
                                icon: 'error',
                                title: resultado.mensagem,
                                confirmButton: {
                                    text: 'Ok',
                                    className: 'btn btn-primary'
                                }
                            }).then((result) => {
                                // Executa uma ação após o usuário clicar no botão "Ok"
                                Swal.close();
                            });
                        }
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        Swal.fire({
                            icon: 'error',
                            title: 'Erro ao salvar o cadastro.',
                            confirmButton: {
                                text: 'Ok',
                                className: 'btn btn-primary'
                            }
                        }).then((result) => {
                            // Executa uma ação após o usuário clicar no botão "Ok"
                            Swal.close();
                        });
                    }
                });
            }

        }
    </script>
</body>

</html>
