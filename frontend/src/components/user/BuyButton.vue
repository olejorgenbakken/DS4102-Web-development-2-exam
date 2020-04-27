<template>
  <button
    class="buy-button"
    @click="addToCart"
    :id="id"
    :style="`background: ${background}; color: ${textColor}`"
  >Kjøp</button>
</template>

<script>
import { store } from "../../store.js";
import axios from "axios";

export default {
  name: "BuyButton",
  props: {
    id: Number,
    textColor: {
      type: String,
      required: false
    },
    background: {
      type: String,
      required: false
    }
  },
  methods: {
    addToCart() {
      let order;
      if (localStorage.getItem("order")) {
        order = JSON.parse(localStorage.getItem("order"));
        let dishesURL = `https://localhost:5001/dishes/${this.id}`;
        axios.get(dishesURL).then(response => {
          order.push({ id: this.id, price: response.data.price });
          localStorage.setItem("order", JSON.stringify(order));
        });
        let total = 0;
        order.forEach(item => {
          total += item.price;
        });
        store.state.total = total;
      } else {
        let dishesURL = `https://localhost:5001/dishes/${this.id}`;
        axios.get(dishesURL).then(response => {
          order = [{ id: this.id, price: response.data.price }];
          localStorage.setItem("order", JSON.stringify(order));
          store.state.total = response.data.price;
        });
      }
    }
  }
};
</script>

<style scoped>
.buy-button {
  font-weight: 700;
  max-width: 200px;
}
</style>