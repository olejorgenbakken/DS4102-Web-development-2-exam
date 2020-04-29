export const store = {
    state: {
        colors: {
            logo: "#eb7e24",
            highlighted: "#345691",
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