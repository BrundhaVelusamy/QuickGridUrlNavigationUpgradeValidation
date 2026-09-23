window.runSelectorValidation = function () {

    const selectors = [
        "button.col-title",
        "a.col-title",
        "button.go-first",
        "a.go-first",
        "button.go-previous",
        "a.go-previous",
        "button.go-next",
        "a.go-next",
        "button.go-last",
        "a.go-last"
    ];

    const lines = [];

    selectors.forEach(selector => {

        const count =
            document.querySelectorAll(selector).length;

        lines.push(
            `${selector} => ${count} matches`
        );
    });

    const result =
        document.getElementById("selector-result");

    if (result) {
        result.textContent = lines.join("\n");
    }
};