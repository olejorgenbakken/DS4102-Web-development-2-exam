export const store = {
    total() {
        let total = 0;
        JSON.parse(localStorage.getItem("order")).forEach(item => {
            total += item.price
        });
        return total;
    }
};