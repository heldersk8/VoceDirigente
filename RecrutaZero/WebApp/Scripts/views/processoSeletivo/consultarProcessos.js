(function ($, self) {
    self.init = function () {
        _registrarEventos();
        _consultar();
        _criarIconeDeAdicionar();
    };

    var _criarIconeDeAdicionar = function () {
        $(".adicionar-novo").prepend("<span class='icon-plus'></span>");
    };

    var _consultar = function () {
        $("form").submit();
    };

    var _abrirProcesso = function () {
        var idProcessoDeSelecao = $(this).data("id");

        if (confirm("Deseja abrir o processo de seleção?")) {
            Loading.Exibir();
            window.location = (window.urlRoot + "ProcessoSeletivo/Abrir/") + idProcessoDeSelecao;
        }
    };

    var _visualizarProcesso = function () {
        var idProcessoDeSelecao = $(this).data("id");

        window.location = (window.urlRoot + "ProcessoSeletivo/Visualizar/") + idProcessoDeSelecao;
    };

    var _registrarEventos = function () {
        $("#OcupacaoId").on("change", _consultar);
        $("body").on("click", "div[status='Pendente']", _abrirProcesso);
        $("body").on("click", "div[status][status!='Pendente']", _visualizarProcesso);
    };
})(jQuery, window.consultarProcessos = window.consultarProcessos || {});