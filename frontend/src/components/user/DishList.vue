<template>
  <section class="dish-list">
    <header class="header">
      <h1 class="headline font-weight-medium">Sushi meny</h1>
    </header>
    <v-container fluid>
      <v-row>
        <v-col cols="12">
          <v-row class="menu-list">
            <DishItem
              v-for="dish in dishes"
              :key="dish.id"
              :id="dish.id"
              :name="dish.name"
              :price="dish.price"
              :description="dish.description"
              :photo="dish.photo"
              :ingredients="JSON.parse(dish.ingredients)"
              :packs="dish.packs"
              :packSize="dish.packSize"
            ></DishItem>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
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
.menu-list {
  padding: 30px 0;
}
</style>