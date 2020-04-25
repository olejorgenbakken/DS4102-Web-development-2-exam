<template>
  <button
    class="buy-button"
    @click="addToCart"
    :id="id"
    :style="`background: ${background}; color: ${textColor}`"
  >Kjøp</button>
</template>

<script>
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
      if (localStorage.getItem("order") == null) {
        let order = [{ id: this.id }];
        localStorage.setItem("order", JSON.stringify(order));
      } else {
        let order = JSON.parse(localStorage.getItem("order"));
        order.push({ id: this.id });
        localStorage.setItem("order", JSON.stringify(order));
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