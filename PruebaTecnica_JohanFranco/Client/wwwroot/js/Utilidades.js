function CustomConfirm(titulo, mensaje, tipo) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar'
        }).then((result) => {
            if (result.isConfirmed) {
                console.log("Confirmado");
                resolve(true);
            }
            else {
                resolve(false);
            }
        })
    });
}
function InputConfirm(titulo, mensaje, input, tipo, valor, mensajeValidador) {
    return new Promise((resolve) => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: tipo,
            input: input,
            inputValue: valor,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Confirmar',
            inputValidator:
                (value) => {
                    if (!value) {
                        return mensajeValidador
                    }
                }
        }).then((result) => {
            if (result.isConfirmed) {
                resolve(result.value);
            }
            else {
                resolve("");
            }
        })
    });
}

function Scroll(elementId) {
    var element = document.getElementById(elementId);
    if (!element) {
        console.warn('element was not found', elementId);
        return false;
    }
    element.scrollIntoView();
}

setTitle = (title) => { document.title = title; };

function initializeInactivityTimer(dotnetHelper) {
    var timer;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
        timer = setTimeout(logout, 1000 * 60 * 30);
    }

    function logout() {
        dotnetHelper.invokeMethodAsync("Logout");
    }

}

function Refresh() {
    location.reload();
}
