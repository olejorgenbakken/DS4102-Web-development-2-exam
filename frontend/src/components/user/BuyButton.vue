<template>
  <button class="buy-button" @click="addToCart" :id="id" :style="`background: ${color}`">Kjøp</button>
</template>

<script>
import axios from "axios";
export default {
  name: "BuyButton",
  props: {
    id: Number,
    color: String
  },
  methods: {
    addToCart() {
      let webAPIUrl = `https://localhost:5001/api/dishes/${this.id}`;

      axios.get(webAPIUrl).then(response => {
        if (localStorage.getItem("order") == null) {
          let order = [response.data];
          localStorage.setItem("order", JSON.stringify(order));
        } else {
          let order = JSON.parse(localStorage.getItem("order"));
          order.push(response.data);
          localStorage.setItem("order", JSON.stringify(order));
        }
      });
    }
  }
};
</script>

<style scoped>
.buy-button {
  color: white;
  width: 100%;
  max-width: 150px;
  padding: 10px;
  font-family: var(--heading);
  font-weight: 700;
  border-radius: 30px;
  transition: 0.3s ease-in-out;
}
</style>