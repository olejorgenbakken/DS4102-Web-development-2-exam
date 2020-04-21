<template>
  <main class="mainpage">
    <DishHighlight></DishHighlight>
    <header class="dish-list-header">
      <h2 class="dish-list-heading">Meny</h2>
    </header>
    <section class="menu">
      <Search></Search>
      <keep-alive>
        <router-view></router-view>
      </keep-alive>
    </section>
  </main>
</template>

<script>
import axios from "axios";
import DishHighlight from "../components/user/DishHighlight.vue";
import Search from "../components/Search";

export default {
  name: "Homepage",
  components: {
    DishHighlight,
    Search
  },
  data() {
    return {
      dishes: []
    };
  },
  beforeMount() {
    const webAPIUrl = `https://localhost:5001/dishes`;
    axios.get(webAPIUrl).then(response => {
      this.dishes = response.data;
    });
  }
};
</script>

<style scoped>
.mainpage {
  display: grid;
  grid-template-rows: calc(100vh - 70px) repeat(2, auto);
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
    grid-template-rows: 500px repeat(2, auto);
  }
}
</style>