<template>
  <section class="order-list">
    <OrderItem v-for="item in order" :key="item.id" :id="item.id"></OrderItem>
  </section>
</template>

<script>
import { store } from "../../store.js";
import OrderItem from "./OrderItem";

export default {
  name: "OrderList",
  components: {
    OrderItem
  },
  data() {
    return {
      order: JSON.parse(localStorage.getItem("order")),
      total: store.state.total
    };
  }
};
</script>

<style scoped>
.order-list {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}

@media only screen and (min-width: 650px) and (max-width: 800px) {
  .order-list {
    grid-template-columns: repeat(2, 1fr);
  }
}
</style>