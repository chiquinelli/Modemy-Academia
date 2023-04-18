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

        <%--        <form id="form1" runat="server">--%>
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
                    <label class="tituloSituacao" for="situacao">Situação do aluno(a)</label> <br>
                    <input class="situacaoAluno" type="radio" name="situacao" id="situacao" value="ativo" runat="server"> <span class="ativo">Ativo</span> 
                    <input class="situacaoAluno" type="radio" name="situacao" id="Radio1" value="inativo" runat="server"> <span class="inativo"> Inativo </span> 
                </div>

                <input class="submit" type="submit" id="btnCadastrar" value="Cadastrar" onclick="Cadastrar(event)">
                <input class="cancel" type="submit" value="Cancelar" onclick="Voltar()">
            </div>
        </div>
        <%--        </form>--%>
    </div>
    <script>
        
    </script>
</body>

</html>
