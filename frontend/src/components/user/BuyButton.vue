<template>
  <button
    class="buy-button"
    @click="addToCart"
    :id="id"
    :style="`background: ${background}; color: ${textColor}`"
  >Kjøp</button>
</template>

<script>
import axios from "axios";
import { store } from "../../store.js";

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
      let dishesURL = `https://localhost:5001/dishes/${this.id}`;
      axios.get(dishesURL).then(response => {
        if (store.state.order == null) {
          store.state.order = [
            { id: response.data.id, amount: 1, price: response.data.price }
          ];
        } else {
          store.state.order.forEach(item => {
            if (item.id == this.id) {
              item.amount++;
            } else {
              console.log(true);
            }
          });
        }
      });
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