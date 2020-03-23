<template>
  <section class="dish-list">
    <h1>Meny</h1>
    <DishItem
      v-for="dish in dishes"
      :key="dish.id"
      :name="dish.name"
      :price="dish.price"
      :description="dish.description"
      :photo="dish.photo"
      :ingredients="JSON.parse(dish.ingredientsJSON)"
    ></DishItem>
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