var Module = (function () {
    var modules = {};
    return {
        create: function (name, credit) {
            if (modules[name] === undefined) {
                modules[name] = {};
            }

            modules[name].credit = function () {
                return credit;
            }
        },
        append: function (name, module) {
            if (modules[name] === undefined) {
                throw 'Module not exists';
            }

            for (var k in module) {
                modules[name][k] = module[k];
            }
        },
        get: function (name) {
            if (modules[name] === undefined) {
                throw 'Module not exists';
            }

            return modules[name];
        }
    }
})();