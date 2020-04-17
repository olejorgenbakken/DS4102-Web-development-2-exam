<template>
  <main class="mainpage">
    <TheHeader class="padding"></TheHeader>
    <DishHighlight></DishHighlight>
    <header class="dish-list-header">
      <h2 class="dish-list-heading">Meny</h2>
    </header>
    <DishList :dishes="menu" class="menu"></DishList>
    <TheFooter></TheFooter>
  </main>
</template>

<script>
import axios from "axios";
import TheHeader from "../components/TheHeader.vue";
import DishHighlight from "../components/user/DishHighlight.vue";
import DishList from "../components/user/DishList.vue";
import TheFooter from "../components/TheFooter.vue";

export default {
  name: "Homepage",
  components: {
    TheHeader,
    DishHighlight,
    DishList,
    TheFooter
  },
  data() {
    return {
      menu: []
    };
  },
  created() {
    const webAPIUrl = `https://localhost:5001/api/dishes`;
    axios.get(webAPIUrl).then(response => {
      this.menu = response.data;
    });
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
  padding-bottom: 100px;
}

@media only screen and (min-width: 700px) {
  .mainpage {
    grid-template-rows: 100px 500px repeat(2, auto);
  }
}
</style>