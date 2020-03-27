<template>
  <article
    class="menu-item"
    v-if="type != null && list.toLowerCase() == type.toLowerCase()"
    :dish="id"
  >
    <figure class="item-photo">
      <img :src="'https:/localhost:5001/images/' + photo" />
    </figure>

    <section class="item-info">
      <h3 class="item-name">
        {{name}}
        <small class="item-price">{{price}} kr</small>
      </h3>
      <p class="item-description">{{description}}</p>

      <router-link :to="'dish/' + id" class="more-button">Les mer</router-link>
      <button class="buy-button" @click="addToCart">Legg til</button>
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
    packs: Boolean,
    type: String,
    list: String
  },
  methods: {
    addToCart() {
      let webAPIUrl = "https://localhost:5001/api/dishes/";

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
  padding-bottom: 80px;
  clip-path: polygon(0 0, 100% 2%, 100% 100%, 0% 100%);
  color: var(--black);
  background: var(--color);
}

.item-name {
  font-size: 1.5em;
}

button {
  position: absolute;
  background: var(--button);
  color: var(--black);
  padding: 10px 25px;
  border-radius: 30px;
  font-size: 0.9em;
  bottom: 20px;
  font-weight: 600;
  font-family: var(--subheading);
  align-self: flex-end;
  width: max-content;
}

.more-button {
  margin-top: 10px;
  margin-bottom: 0;
  width: max-content;
}

.buy-button {
  right: 20px;
}

.item-description {
  margin-bottom: 0;
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