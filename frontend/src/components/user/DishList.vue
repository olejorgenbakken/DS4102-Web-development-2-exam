<template>
  <section class="dish-list">
    <DishItem v-for="dish in dishes" :key="dish.id" :dishId="dish.id"></DishItem>
  </section>
</template>

<script>
import DishItem from "./DishItem";

export default {
  name: "DishList",
  components: {
    DishItem
  },
  props: {
    dishes: Array
  }
};
</script>

<style scoped>
.dish-list {
  width: 100%;
  max-width: 1000px;
  margin: 0 auto;
  display: grid;
  grid-template-columns: 1fr;
  gap: 50px;
  padding: 0 20px;
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 5px 20px;
}

@media only screen and (min-width: 700px) {
  .dish-list {
    grid-template-columns: repeat(3, 1fr);
  }
}

@media only screen and (min-width: 1000px) {
  .dish-list {
    grid-template-columns: repeat(4, 1fr);
  }
}
</style>