<template>
  <article
    class="menu-item"
    v-if="type != null && list.toLowerCase() == type.toLowerCase()"
    :dish="id"
  >
    <figure class="item-photo">
      <img :src="photo" />
    </figure>

    <section class="item-info" :style="'background:' + color">
      <h3 class="item-name">
        {{name}}
        <small class="item-price">{{price}} kr</small>
      </h3>
      <p class="item-description">{{description}}</p>

      <button class="item-button" @click="addToCart">Legg til</button>
    </section>
  </article>
</template>

<script>
import axios from "axios";

export default {
  name: "Dish",
  props: {
    id: Number,
    name: String,
    description: String,
    price: Number,
    photo: String,
    ingredients: Array,
    packs: Boolean,
    packSize: Number,
    type: String,
    list: String,
    color: String
  },
  methods: {
    addToCart() {
      let webAPIUrl = "https://localhost:5001/dishes/";

      axios.get(webAPIUrl).then(response => {
        response.data.forEach(dish => {
          if (dish.id == this.$el.getAttribute("dish")) {
            if (localStorage.getItem("order") == null) {
              let order = [dish];
              localStorage.setItem("order", JSON.stringify(order));
            } else {
              let order = JSON.parse(localStorage.getItem("order"));
              order.push(dish);
              localStorage.setItem("order", JSON.stringify(order));
            }
          }
        });
      });
    }
  }
};
</script>

<style scoped>
.menu-item {
  position: relative;
}

.item-photo {
  position: absolute;
  height: 180px;
  width: 100%;
}

.item-photo img {
  height: 100%;
  width: 100%;
  object-fit: cover;
}

.item-info {
  position: relative;
  display: flex;
  flex-direction: column;
  margin-top: 140px;
  padding: 20px 10px;
  height: 200px;
  clip-path: polygon(0 0, 100% 2%, 100% 100%, 0% 100%);
  color: var(--black);
}

.item-name {
  font-size: 1.5em;
}

.item-button {
  position: absolute;
  background: white;
  padding: 10px 25px;
  border-radius: 30px;
  font-size: 0.9em;
  bottom: 20px;
  right: 20px;
  font-weight: 600;
  font-family: var(--subheading);
  align-self: flex-end;
  width: max-content;
}

@media only screen and (min-width: 420px) {
  .item-photo {
    height: 190px;
  }

  .item-info {
    margin-top: 170px;
  }
}
</style>