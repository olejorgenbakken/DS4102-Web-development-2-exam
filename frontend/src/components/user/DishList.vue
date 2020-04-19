<template>
  <section class="wrapper">
    <section class="search" v-if="!this.$route.params.id">
      <input type="search" placeholder="Søk" v-model="searchTerm" autofocus @keypress="search" />
    </section>

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
import DishItem from "./DishItem";

export default {
  name: "DishList",
  components: {
    DishItem
  },
  data() {
    return {
      dishes: Array,
      searchTerm: undefined
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
          if (dish.name.toLowerCase().includes(this.searchTerm)) {
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

.search {
  font-family: var(--heading);
  width: 100%;
  display: flex;
  flex-direction: column;
  position: relative;
  background: #ffffff;
}

.search::after {
  position: absolute;
  bottom: 0;
  left: 0;
  content: "";
  width: 100%;
  height: 1px;
  background: black;
}

.search input {
  width: 100%;
  padding: 15px;
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