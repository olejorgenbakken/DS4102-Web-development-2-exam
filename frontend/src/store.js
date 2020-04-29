export const store = {
    state: {
        colors: {
            logo: "#0977ff",
            highlighted: "#b7a900",
            highlightedText: "#ffffff"
        }
    },
    total() {
        let total = 0;
        if (localStorage.getItem("order")) {
            JSON.parse(localStorage.getItem("order")).forEach(item => {
                total += item.price
            });
        }
        return total;
    }
};