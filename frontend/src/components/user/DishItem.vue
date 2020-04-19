<template>
  <router-link :to="{ name: 'Details', params: {id: id}}">
    <article class="menu-item">
      <figure class="item-photo">
        <img :src="`https:/localhost:5001/images/${photo}`" />
      </figure>

      <h3 class="item-title">
        {{name}}
        <small class="item-price">{{price}}kr</small>
      </h3>
    </article>
  </router-link>
</template>

<script>
import axios from "axios";
export default {
  name: "Dish",
  props: {
    id: Number,
    name: String,
    photo: String,
    price: Number
  },
  data() {
    return {
      theDish: {}
    };
  },
  created() {
    let webAPIUrl = `https://localhost:5001/api/dishes/${this.id}`;
    axios.get(webAPIUrl).then(response => {
      this.theDish = response.data;
    });
  }
};
</script>

<style scoped>
.item-photo {
  border-radius: 10px;
  overflow: hidden;
  height: 200px;
  position: relative;
}

.item-photo img {
  height: 100%;
  width: 100%;
  object-fit: cover;
}

.item-title {
  width: 100%;
  padding: 5px;
  font-weight: 700;
  grid-area: title;
}

.item-price {
  font-weight: 500;
}

.item-description {
  grid-area: description;
}

.buy-button {
  margin: 0 auto;
  padding: 10px 30px;
  grid-area: buy;
}

.more-button {
  font-family: var(--paragraph);
  color: black;
  font-weight: 600;
  grid-area: more;
  width: max-content;
  padding: 5px 5px 5px 2px;
}
</style>