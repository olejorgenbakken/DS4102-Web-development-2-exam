<template>
  <main class="mainpage">
    <TheHeader class="padding"></TheHeader>
    <DishHighlight></DishHighlight>
    <header class="dish-list-header">
      <h2 class="dish-list-heading">Meny</h2>
    </header>
    <section class="menu">
      <Search v-model="searchTerm" @input="search"></Search>
      <DishList :dishes="dishes"></DishList>
    </section>

    <TheFooter></TheFooter>
  </main>
</template>

<script>
import axios from "axios";
import TheHeader from "../components/TheHeader.vue";
import DishHighlight from "../components/user/DishHighlight.vue";
import Search from "../components/Search";
import DishList from "../components/user/DishList.vue";
import TheFooter from "../components/TheFooter.vue";

export default {
  name: "Homepage",
  components: {
    TheHeader,
    DishHighlight,
    Search,
    DishList,
    TheFooter
  },
  data() {
    return {
      searchTerm: undefined,
      dishes: []
    };
  },
  beforeMount() {
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
.mainpage {
  display: grid;
  grid-template-rows: 70px calc(100vh - 70px) repeat(2, auto);
}

.dish-list-heading {
  text-align: center;
  display: flex;
  justify-content: center;
  align-items: center;
  font-weight: 900;
  text-transform: uppercase;
}

.dish-list-heading::after,
.dish-list-heading::before {
  content: "";
  display: block;
  height: 2px;
  width: 50px;
  background: black;
  margin: 0 10px;
}

.dish-list-header {
  padding: 40px 0 20px 0;
}

.menu {
  width: 100%;
  max-width: 1000px;
  min-height: 50vh;
  margin: 0 auto;
  padding: 0 20px 60px 20px;
  display: grid;
  grid-template-columns: 1fr;
  gap: 40px;
}

@media only screen and (min-width: 700px) {
  .mainpage {
    grid-template-rows: 100px 500px repeat(2, auto);
  }
}
</style>