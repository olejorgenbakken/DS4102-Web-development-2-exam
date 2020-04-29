<template>
  <section class="items">
    <header>
      <h4>Varer</h4>
    </header>
    <section class="items-carousel">
      <OrderItemItem v-for="item in JSON.parse(items)" :key="item.id" :id="item.id"></OrderItemItem>
    </section>
  </section>
</template>

<script>
import OrderItemItem from "./OrderItemItem";
export default {
  name: "OrderItemList",
  props: {
    items: String
  },
  components: {
    OrderItemItem
  }
};
</script>

<style scoped>
.items header {
  padding: 0 20px;
}

.items-carousel {
  display: flex;
  flex-direction: row;
  overflow: auto;
  height: 300px;
  width: 100%;
  padding: 10px 20px;
}
</style>