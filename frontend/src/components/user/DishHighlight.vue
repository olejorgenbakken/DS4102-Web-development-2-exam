<template>
  <article class="highlighted">
    <section
      class="photo"
      :style="'background-image: url(https:localhost:5001/images/' + dish.photo + ')'"
    ></section>
    <section class="info" :style="`background: ${color}; color: ${text}`">
      <section class="text">
        <h2 class="title">
          {{dish.name}}
          <small>fra {{dish.price}}kr</small>
        </h2>
        <p>{{dish.description}}</p>
      </section>

      <section class="links">
        <router-link :to="{ name: 'Details', params: {id: dish.id}}">
          <button class="more-button" :style="`border: 3px solid ${text}; color: ${text}`">Les mer</button>
        </router-link>
        <BuyButton
          :id="dish.id"
          :style="`background: ${text}; color: ${color}`"
          class="buy-button card card-photo"
        ></BuyButton>
      </section>
    </section>
  </article>
</template>

<script>
import axios from "axios";
import BuyButton from "./BuyButton";

export default {
  name: "DishHighlight",
  components: {
    BuyButton
  },
  props: {
    color: String,
    text: String
  },
  data() {
    return {
      dish: {},
      settings: {}
    };
  },
  beforeMount() {
    let highlightedDish = "https://localhost:5001/dishes/highlighted/true";
    axios.get(highlightedDish).then(response => {
      if (response.status != 200) {
        let randomDish = "https://localhost:5001/dishes";
        axios.get(randomDish).then(response => {
          let rnd = Math.floor(Math.random() * response.data.length);
          this.dish = response.data[rnd];
        });
      }
      this.dish = response.data;
    });
  }
};
</script>

<style scoped>
.highlighted {
  position: relative;
  display: grid;
  grid-template-rows: 1fr auto;
  grid-template-areas:
    "pic"
    "info";
  width: 100%;
  height: 100%;
  max-width: 1300px;
  margin: 0 auto;
}

.photo {
  grid-area: pic;
  width: 100%;
  height: 100%;
  background-size: cover;
  background-position: center center;
}

.info {
  grid-area: info;
  padding: 20px 20px 30px 20px;
}

.text {
  width: 100%;
  max-width: 400px;
  padding-bottom: 20px;
}

.links {
  width: 100%;
  max-width: 400px;
  display: grid;
  gap: 20px;
  grid-template-columns: 120px 1fr;
}

.more-button {
  background: transparent;
  width: 100%;
  height: 100%;
}

.buy-button::after {
  background: transparent;
}

@media only screen and (min-width: 700px) {
  .highlighted {
    grid-template-columns: repeat(8, 1fr);
    grid-template-rows: 1fr;
    grid-template-areas: "info info info info info pic pic pic";
  }

  .info {
    height: 100%;
    grid-area: info;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
  }

  .links {
    display: grid;
    gap: 20px;
    grid-template-columns: 120px 1fr;
    justify-content: flex-start;
  }
}
</style>