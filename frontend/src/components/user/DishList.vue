<template>
  <section class="wrapper">
    <Search :placeholder="placeholder" v-model="searchTerm" @input="search"></Search>

    <section class="dish-list">
      <DishItem
        v-for="dish in dishes"
        :key="dish.id"
        :id="dish.id"
        :name="dish.name"
        :photo="dish.photo"
        :price="dish.price"
      ></DishItem>
    </section>
  </section>
</template>

<script>
import axios from "axios";
import Search from "../Search";
import DishItem from "./DishItem";

export default {
  name: "DishList",
  components: {
    DishItem,
    Search
  },
  data() {
    return {
      dishes: [],
      placeholder: "Søk",
      searchTerm: ""
    };
  },
  created() {
    const webAPIUrl = `https://localhost:5001/api/dishes`;
    axios.get(webAPIUrl).then(response => {
      this.dishes = response.data;
    });
  },
  methods: {
    search() {
      const webAPIUrl = `https://localhost:5001/api/dishes/`;
      axios.get(webAPIUrl).then(response => {
        let dishes = [];
        response.data.forEach(dish => {
          if (
            dish.name.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
            dish.type.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
            dish.description
              .toLowerCase()
              .includes(this.searchTerm.toLowerCase())
          ) {
            dishes.push(dish);
            this.dishes = dishes;
          } else {
            this.dishes = dishes;
          }
        });
      });
    }
  }
};
</script>

<style scoped>
.wrapper {
  width: 100%;
  max-width: 1000px;
  margin: 0 auto;
  padding: 0 20px;
  display: grid;
  grid-template-columns: 1fr;
  gap: 40px;
}

.dish-list {
  display: grid;
  grid-template-columns: 1fr;
  gap: 50px;
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