<template>
  <section class="dish">
    <TheHeader class="padding"></TheHeader>
    <router-view>
      <DetailedDish></DetailedDish>
    </router-view>

    <section class="related">
      <header>
        <h3>Andre retter</h3>
      </header>
      <section class="dishes">
        <DishList></DishList>
      </section>
    </section>
    <TheFooter></TheFooter>
  </section>
</template>

<script>
import TheHeader from "../components/TheHeader.vue";
import DetailedDish from "../components/user/DetailedDish";
import DishList from "../components/user/DishList";
import TheFooter from "../components/TheFooter.vue";
export default {
  name: "Dish",
  components: {
    TheHeader,
    TheFooter,
    DishList,
    DetailedDish
  }
};
</script>

<style scoped>
.dish {
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: 70px repeat(2, auto);
  width: 100%;
}

.related {
  width: 100%;
  max-width: 1000px;
  margin: 0 auto;
  padding-bottom: 20px;
}

.related header {
  padding: 40px 20px 10px 20px;
}

@media only screen and (min-width: 800px) {
  .dish {
    grid-template-rows: 100px 400px auto;
    gap: 20px;
  }
}
</style>