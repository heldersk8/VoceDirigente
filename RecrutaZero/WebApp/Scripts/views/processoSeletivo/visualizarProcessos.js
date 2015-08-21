(function ($, self) {
    self.init = function () {
        _registrarEventos();
    };

    var _abrirAptidoes = function () {
        var data = {
            processoSeletivoId: $("#ProcessoSeletivoId").val(),
            candidatoParaSelecaoId: $(this).data("id")
        };

        $.get(window.urlRoot + "ProcessoSeletivo/Aptidoes/", data, function (response) {
            $("#dialogAptidoes").empty().html(response).dialog({
                autoOpen: true,
                modal: true,
                title: "Aptidões do candidato",
            });
        });
    };

    var _contratar = function () {
        var containerDosBotoes = $(this).parent();
        
        var data = {
            processoSeletivoId: $("#ProcessoSeletivoId").val(),
            candidatoParaSelecaoId: $(this).data("id")
        };

        $.post(window.urlRoot + "ProcessoSeletivo/Contratar/", data, function() {
            $("input", containerDosBotoes).remove();
            
            var cabecalhoAtual = $("h3", containerDosBotoes.parent()).html();
            $("h3", containerDosBotoes.parent()).html(cabecalhoAtual.replace("(Não contratado)", "(Contratado)"));
        });
    };

    var _avaliarAptidao = function () {
        var containerDaAptidao = $(this).parent();
        
        if ($("#data", containerDaAptidao).val() == "") {
            $("div.validation-summary-errors", containerDaAptidao).fadeIn(1000).delay(2000).fadeOut(1000);
            return;
        }
        
        var data = {
            candidatoParaSelecaoId: $("#candidatoParaSelecaoId", containerDaAptidao).val(),
            passoId: $("#passoId", containerDaAptidao).val(),
            observacao: $("#observacao", containerDaAptidao).val(),
            data: $("#data", containerDaAptidao).val(),
            apto: $("#apto", containerDaAptidao).is(":checked")
        };

        $.post(window.urlRoot + "ProcessoSeletivo/SalvarAptidao/", data, function() {
            $("div.mensagemDeSucessoModal", containerDaAptidao).fadeIn(1000).delay(2000).fadeOut(1000);
        });
    };

    var _abrirAccordion = function () {
        $(this).next().slideToggle();
    };

    var _encerrarProcesso = function () {
        var data = {
            processoSeletivoId: $("#ProcessoSeletivoId").val()
        };
        
        Loading.Exibir();

        $.post(window.urlRoot + "ProcessoSeletivo/Encerrar/", data, function () {
            var urlAtual = window.location.toString().indexOf("ProcessoSeletivo/");
            
            window.location = window.urlRoot + window.location.toString().substring(urlAtual);
        });
    };

    var _registrarEventos = function () {
        $("body").on("click", "button.avaliar-aptidao", _avaliarAptidao);
        $("input.aptidoes").on("click", _abrirAptidoes);
        $("input.contratar").on("click", _contratar);
        $("body").on("click", ".ui-dialog div.info-candidato h3", _abrirAccordion);
        $("#btnEncerrarProcesso").on("click", _encerrarProcesso);
    };
})(jQuery, window.visualizarProcessos = window.visualizarProcessos || {});