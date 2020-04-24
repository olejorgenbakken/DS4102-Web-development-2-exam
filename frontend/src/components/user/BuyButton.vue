<template>
  <button
    :style="`background: ${text}; color: ${color}`"
    class="buy-button"
    @click="addToCart"
    :id="id"
  >Kjøp</button>
</template>

<script>
import axios from "axios";
export default {
  name: "BuyButton",
  props: {
    id: Number
  },
  data() {
    return {
      color: String,
      text: String
    };
  },
  created() {
    const settingsURL = `https://localhost:5001/settings/1`;
    axios.get(settingsURL).then(response => {
      this.color = response.data.color;
      this.text = response.data.text;
    });
  },
  methods: {
    addToCart() {
      let webAPIUrl = `https://localhost:5001/dishes/${this.id}`;

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
  font-weight: 700;
  max-width: 200px;
}
</style>