<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link rel="shortcut icon" href="../src/imagens/fav-icone.png" type="image/x-icon">

    <title>Modemy - Cadastre-se na nossa plataforma</title>

    <link rel="stylesheet" href="../src/css/cadastroAlunoStyles.css">
    <link rel="stylesheet" href="../src/css/responsive.css">
    <link rel="stylesheet" href="../src/css/reset.css">
    <link rel="stylesheet" href="../src/css/Swal.css">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@800&family=Poppins:wght@100;300;500&display=swap" rel="stylesheet">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../src/js/Swal.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>

</head>
<body>
    <div class="formAluno">

        <img src="../src/imagens/logo.jpg" alt="">

        <div id="form1">

            <div class="prr">
                <div class="divName">
                    <label for="nome">Nome do aluno(a)</label>
                    <input class="nome campoAluno" type="text" name="nome" id="nome" runat="server">
                </div>

                <div class="divTelefone">
                    <label for="telefone">Telefone</label>
                    <br>
                    <input class="telefone campoAluno" type="text" name="telefone" id="telefone" runat="server">
                </div>

                <div class="divCep">
                    <label for="cep">CEP</label>
                    <input class="cep campoAluno" type="text" name="cep" id="cep" runat="server">
                </div>

                <div class="divEndereco">
                    <label for="endereco">Endereço</label>
                    <input class="endereco campoAluno" type="text" name="endereco" id="endereco" runat="server">
                </div>

                <div class="divNumero">
                    <label for="numero">Nº</label>
                    <input class="numero campoAluno" type="text" name="numero" id="numero" runat="server">
                </div>

                <div class="divCidade">
                    <label for="cidade">Cidade</label>
                    <input class="campoAluno" type="text" name="numero" id="cidade" runat="server">
                </div>

                <div class="divEstado">
                    <label for="estado">UF</label>
                    <input class="campoAluno" type="text" name="numero" id="estado" runat="server">
                </div>

                <div class="divSituacao">
                    <label class="tituloSituacao" for="situacao">Situação do aluno(a)</label>
                    <br>
                    <input class="situacaoAluno" type="radio" name="situacao" id="ativo" value="true" runat="server">
                    <span class="ativo">Ativo</span>
                    <input class="situacaoAluno" type="radio" name="situacao" id="inativo" value="false" runat="server">
                    <span class="inativo">Inativo </span>
                </div>

                <input class="submit" type="submit" id="btnCadastrar" value="Cadastrar" onclick="Cadastrar(event)">
                <input class="cancel" type="submit" value="Cancelar" onclick="Voltar()">
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {

            $("#telefone").mask('(00) 00000-0000');
            $("#cep").mask('00000-000');
            const buscaCep = $('#cep');

            buscaCep.on('blur', function () {
                BuscarCep();
            });
            if (window.location.search.includes("idAluno=")) {
                const urlParams = new URLSearchParams(window.location.search);
                const idAluno = urlParams.get('idAluno');
                if (idAluno != null) {
                    CarregarObj(idAluno, function (aluno) {
                        var telefone = aluno.Telefone
                        var cep = aluno.Cep;
                        // adicione a máscara do telefone e cep
                        telefone = telefone.replace(/^(\d{2})(\d{4,5})(\d{4})$/, "($1) $2-$3");
                        cep = cep.replace(/^(\d{5})(\d{3})$/, "$1-$2");
                        $("#cep").val(cep);
                        $("#telefone").val(telefone);
                        $("#nome").val(aluno.NomeCompleto);
                        $("#endereco").val(aluno.Endereco);
                        $("#numero").val(aluno.NumeroEndereco);
                        $("#cidade").val(aluno.Cidade);
                        $("#estado").val(aluno.Uf);
                        $("#btnCadastrar").val("Editar");
                        if (aluno.Ativo == true) { $("#ativo").prop("checked", true); }
                        if (aluno.Ativo == false) { $("#inativo").prop("checked", true); }

                        // Muda o onclick para "EditarCadastro"
                        $("#btnCadastrar").attr("onclick", "EditarCadastro(event)");
                        setTimeout(function () {
                            $("#telefone").mask('(00) 00000-0000');
                            $("#cep").mask('00000-000');
                        }, 100);
                    });
                }
            }

        });
        //function Cadastrar(event) {
        //    event.preventDefault(); // evita o comportamento padrão do botão

        //    window.location.href = "../cadastro/cadastroaluno"; // redireciona para a outra página
        //}
        //$("#btnCadastrar").click(() => {
        //    event.preventDefault();
        //    window.location.href = "../cadastro/cadastroaluno"; // redireciona para a outra página
        //});
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
                        document.getElementById('cidade').value = data.localidade;
                        document.getElementById('estado').value = data.uf;

                    }
                })
                .catch(error => {
                    console.log('CEP inválido:');
                });
        }
        function ValidarCampos() {
            // Selecionando os campos
            nome = $("#nome").val();
            telefone = $("#telefone").val();
            cep = $("#cep").val();
            numero = $("#numero").val();
            endereco = $("#endereco").val();
            cidade = $("#cidade").val();
            estado = $("#estado").val();
            if ($("#ativo").prop("checked")) { ativo = true; }
            if ($("#inativo").prop("checked")) { ativo = false; }
            if (ativo == null || ativo == undefined) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Por favor, selecione Ativo ou Inativo.',
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


            // Verifica se os campos não estão vazios
            if (nome === "" || telefone === "" || cep === "" || endereco === "" || numero === "" || cidade === "" || estado === "") {
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
            if (cep.length != 9) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Por favor colque um cep válido.',
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
            if (telefone.length != 15) {
                Swal.fire({
                    icon: 'warning',
                    title: 'Por favor colque um telefone válido.',
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

            cep = cep.replace(/[-]/g, '');
            telefone = telefone.replace(/[()-\s]/g, '');


            // Se todas as validações passarem, retorna true
            return true;

        }
        function Voltar() {
            window.location.href = '../Aluno/Alunos.aspx';

        }
        function CarregarObj(idAluno, callback) {
            $.ajax({
                type: "POST",
                url: "Cadastro.ashx/Cadastrar",
                data: { id: idAluno, method: "RecuperarObjAluno" },
                success: function (response) {
                    var objaluno = JSON.parse(response);

                    if (objaluno != undefined) {
                        callback(objaluno);
                    } else {
                        callback(null, "Erro ao carregar dados do ID " + idAluno + ". Por favor tente outro ID.");
                    }
                },
                error: function (error) {
                    callback(null, error);
                }
            });
        }

        function Cadastrar() {
            if (ValidarCampos()) {
                $.ajax({
                    type: "POST",
                    url: "Cadastro.ashx/Cadastrar",
                    data: { nome: nome, telefone: telefone, cep: cep, endereco: endereco, numero: numero, uf: estado, cidade: cidade, statusAluno: ativo, method: "CadastrarAluno" },
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
        function EditarCadastro() {
            if (ValidarCampos()) {
                const urlParams = new URLSearchParams(window.location.search);
                const idAluno = urlParams.get('idAluno');
                $.ajax({
                    type: "POST",
                    url: "Cadastro.ashx/Cadastrar",
                    data: { id: idAluno, nome: nome, telefone: telefone, cep: cep, endereco: endereco, numero: numero, uf: estado, cidade: cidade, statusAluno: ativo, method: "EditarAluno" },
                    success: function (response) {
                        var resultado = JSON.parse(response);

                        if (resultado.status === "success") {
                            Swal.fire({
                                icon: 'success',
                                title: 'O cadastro foi editado com sucesso!',
                                confirmButton: {
                                    text: 'Ok',
                                    className: 'btn btn-primary'
                                }
                            }).then((result) => {
                                // Executa uma ação após o usuário clicar no botão "Ok"
                                Swal.close();
                                window.location.href = '../Aluno/Alunos.aspx';

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
