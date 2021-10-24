Module.create("form-validation", {

});

Module.append("form-validation", {

    InitValidation:
        function (form) {
            'use strict'

            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = form ? document.querySelectorAll(form) : document.querySelectorAll('.needs-validation')

            // Loop over them and prevent submission
            Array.prototype.slice.call(forms)
                .forEach(function (form) {
                    form.addEventListener('submit', function (event) {
                        if (!form.checkValidity()) {
                            event.preventDefault()
                            event.stopPropagation()
                        }

                        form.classList.add('was-validated')
                    }, false)
                })
        },

    GetDataForm: function (datahtml, data) {
        var inputs = $("input[" + datahtml + "], textarea[" + datahtml + "], select[" + datahtml + "]");

        let request = {};
        $.each(inputs, function (i, element) {
            let name = $(element).data(data || "name");
            request[name] = $(element).is(":checkbox") ? $(element).is(":checked") : $(element).val();
        });

        return request;
    },

    SetDataForm: function (datahtml, data) {
        var inputs = $("input[" + datahtml + "], textarea[" + datahtml + "], select[" + datahtml + "]");

        let request = {};
        for (let name in data) {

            let control = datahtml ? $("input[" + datahtml + "=" + this.capitalizarPrimeraLetra(name) + "], textarea[" + datahtml + "=" + this.capitalizarPrimeraLetra(name) + "], select[" + datahtml +"=" + this.capitalizarPrimeraLetra(name) + "]") : $("input[data-name=" + this.capitalizarPrimeraLetra(name) + "], textarea[data-name=" + this.capitalizarPrimeraLetra(name) + "], select[data-name=" + this.capitalizarPrimeraLetra(name) + "]");
            if ($(control).is(":checkbox"))
                $(control).attr("checked", data[name] === "true" ? true : false);
            else
                $(control).val(data[name]);
        }

        return request;
    },

    capitalizarPrimeraLetra: function (str) {
        return str.charAt(0).toUpperCase() + str.slice(1);
    }

});