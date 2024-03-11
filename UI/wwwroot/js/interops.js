window.getCursorPosition = (elementId) => {
    const el = document.getElementById(elementId);
    if (el) {
        return el.selectionStart;
    } else {
        return -1;
    }
}

window.setCursorPosition = (elementId, pos) => {
    const el = document.getElementById(elementId);
    if (el) {
        el.focus();
        el.setSelectionRange(pos, pos);
    }
}

window.scrollToElement = (elementId) => {
    const element = document.getElementById(elementId);

    if (element) {
        element.scrollIntoView({ behavior: 'smooth' });
    }
};

window.blurInputField = function (element) {
    element.blur();
};

window.focusInputField = function (element) {
    element.focus();
};

export function registerShortcut(dotnetHelper) {
    function keydownHandler(e) {
        if (e.ctrlKey && e.key === 'k') {
            e.preventDefault();
            dotnetHelper.invokeMethodAsync('OnCtrlKPressed');
        }

        if (e.key === 'Enter') {
            e.preventDefault();
            dotnetHelper.invokeMethodAsync('OnEnterPressed');
        }

        if (e.key === 'Escape') {
            e.preventDefault();
            dotnetHelper.invokeMethodAsync('OnEscapePressed');
        }
    }

    document.addEventListener('keydown', keydownHandler);

    return {
        dispose: () => document.removeEventListener('keydown', keydownHandler)
    };
};