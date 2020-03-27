<template>
  <section class="dish-list" id="menu">
    <header class="dish-list-header">
      <h2 class="dish-list-heading">Meny</h2>
    </header>
    <section class="menu" v-for="type in dishTypes" :key="type">
      <header class="menu-header">
        <h3>{{type}}</h3>
      </header>
      <DishItem
        v-for="dish in dishes"
        :key="dish.id"
        :id="dish.id"
        :name="dish.name"
        :price="dish.price"
        :description="dish.description"
        :photo="dish.photo"
        :packs="dish.packs"
        :type="dish.type"
        :list="type"
      ></DishItem>
    </section>
  </section>
</template>

<script>
import DishItem from "./DishItem";

export default {
  name: "DishList",
  components: {
    DishItem
  },
  data() {
    return {
      dishTypes: ["Maki", "Sashimi", "Nigiri", "Vegetar"]
    };
  },
  props: {
    dishes: Array,
    color: String
  }
};
</script>

<style scoped>
#menu {
  display: grid;
  grid-template-columns: 1fr;
  gap: 50px;
  padding: 30px;
  width: 100%;
  max-width: 1000px;
  margin: 0 auto;
}

.dish-list-heading {
  margin-bottom: -35px;
}

.dish-list-heading {
  font-size: 1.7em;
  font-weight: 600;
}

.menu-header {
  display: flex;
  justify-content: flex-start;
  align-items: center;
  font-family: var(--subheading);
  font-size: 0.8em;
}

.menu-header::before {
  content: "";
  height: 2px;
  width: 10px;
  background: var(--black);
  display: block;
  margin-right: 10px;
}

.menu {
  display: grid;
  grid-template-columns: 1fr;
  grid-template-areas:
    "header"
    "items";
  gap: 10px 20px;
}

.menu-header {
  grid-area: header;
}

@media only screen and (min-width: 650px) {
  .menu {
    grid-template-columns: 1fr 1fr;
    grid-template-areas:
      "header header"
      "items items";
  }
}

@media only screen and (min-width: 1000px) {
  .menu {
    grid-template-columns: 1fr 1fr 1fr;
    grid-template-areas:
      "header header header"
      "items items items";
  }
}
</style>