export const store = {
    state: {
        loggedIn: false,
        isAdmin: false,
        user: null,
        colors: {
            highlighted: "#1d2874",
            highlightedText: "#ffffff",
            logo: "#04a5be"
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