<template>
  <router-link v-if="list == type" class="dish card" :to="{ name: 'Dish', params: {id: id}}">
    <figure class="photo">
      <img :src="`https:/localhost:5001/images/${photo}`" />
    </figure>
    <section class="info">
      <h4 class="title">
        {{name}}
        <small class="price">{{price}}kr</small>
      </h4>
      <p class="desc">{{description}}</p>
    </section>
  </router-link>
</template>

<script>
export default {
  name: "Dish",
  props: {
    id: Number,
    name: String,
    photo: String,
    price: Number,
    description: String,
    type: String,
    list: String
  }
};
</script>

<style scoped>
.photo {
  height: 200px;
}

.info {
  padding: 10px 15px 20px 15px;
}

.desc {
  margin-top: 3px;
}
</style>