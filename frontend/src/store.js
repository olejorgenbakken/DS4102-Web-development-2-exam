export const store = {
    state: {
        loggedIn: false,
        isAdmin: false,
        user: null,
        colors: {
            highlighted: "#447eff",
            highlightedText: "#ffffff",
            logo: "#ff5c42"
        },
    },
    total() {
        let total = 0;
        JSON.parse(localStorage.getItem("order")).forEach(item => {
            total += item.price
        });
        return total;
    }
};