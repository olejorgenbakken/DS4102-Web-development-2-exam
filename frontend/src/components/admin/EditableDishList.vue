<template>
  <section class="dishes">
    <DishItem v-for="dish in dishes" :key="dish.id" :id="dish.id"></DishItem>
  </section>
</template>

<script>
import DishItem from "./EditableDishItem";

export default {
  name: "EditableDishList",
  components: {
    DishItem
  },
  props: {
    dishes: Array
  }
};
</script>

<style scoped>
.dishes {
  display: grid;
  grid-template-columns: 1fr;
  gap: 40px;
}

@media only screen and (min-width: 600px) {
  .dishes {
    grid-template-columns: repeat(2, 1fr);
  }
}

@media only screen and (min-width: 1000px) {
  .dishes {
    grid-template-columns: repeat(3, 1fr);
  }
}

@media only screen and (min-width: 1100px) {
  .dishes {
    grid-template-columns: 1fr;
    gap: 20px;
  }
}
</style>