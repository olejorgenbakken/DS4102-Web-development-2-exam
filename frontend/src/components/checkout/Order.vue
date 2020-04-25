<template>
  <section class="order">
    <OrderItem v-for="item in order" :key="item.id" :id="item.id"></OrderItem>
  </section>
</template>

<script>
import OrderItem from "./OrderItem";

export default {
  name: "Basket",
  components: {
    OrderItem
  },
  data() {
    return {
      order: null
    };
  },
  created() {
    this.order = JSON.parse(localStorage.getItem("order"));
  }
};
</script>

<style scoped>
.order {
  width: 100%;
  max-width: 900px;
  margin: 0 auto;
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}
</style>