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
        order: null,
    },
    calculateTotal() {
        let total = 0;
        this.state.order.forEach(item => {
            total += item.amount * item.price
        });

        return total;
    }
};