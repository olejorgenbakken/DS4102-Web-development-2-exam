<template>
  <main class="mainpage">
    <router-view></router-view>
    <DishHighlight></DishHighlight>
    <section class="menu">
      <header class="menu-header">
        <h2>Meny</h2>
        <Search></Search>
      </header>
      <DishList></DishList>
    </section>
  </main>
</template>

<script>
import DishHighlight from "../components/user/DishHighlight.vue";
import Search from "../components/Search";
import DishList from "../components/DishList";

export default {
  name: "Homepage",
  components: {
    DishHighlight,
    Search,
    DishList
  }
};
</script>

<style scoped>
.menu {
  width: 100%;
  max-width: 1000px;
  padding: 20px;
  margin: 0 auto;
}

.menu-header {
  display: flex;
  flex-direction: column;
  padding-bottom: 20px;
}

.menu-header h2 {
  margin-bottom: 20px;
}

@media only screen and (min-width: 800px) {
  .menu {
    padding: 50px 20px;
  }

  .menu-header {
    display: flex;
    flex-direction: column;
    padding-bottom: 30px;
  }
}
</style>