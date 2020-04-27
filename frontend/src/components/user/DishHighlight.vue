<template>
  <article class="highlighted">
    <section
      class="photo"
      :style="'background-image: url(https:localhost:5001/images/' + dish.photo + ')'"
    ></section>
    <section
      class="info"
      :style="`background: ${colors.highlighted}; color: ${colors.highlightedText}`"
    >
      <section class="text">
        <h2 class="title">
          {{dish.name}}
          <small class="price">{{dish.price}}kr</small>
        </h2>

        <p class="desc">{{dish.description}}</p>
      </section>

      <section class="links">
        <router-link :to="{ name: 'Dish', params: {id: dish.id}}">
          <button
            class="more-button"
            :style="`border: 3px solid ${colors.highlightedText}; color: ${colors.highlightedText}`"
          >Les mer</button>
        </router-link>
        <BuyButton
          :id="dish.id"
          :background="colors.highlightedText"
          :textColor="colors.highlighted"
        ></BuyButton>
      </section>
    </section>
  </article>
</template>

<script>
import { store } from "../../store.js";
import axios from "axios";
import BuyButton from "./BuyButton";

export default {
  name: "DishHighlight",
  components: {
    BuyButton
  },
  data() {
    return {
      dish: {},
      settings: {},
      colors: store.state.colors
    };
  },
  created() {
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
  display: flex;
  flex-direction: column;
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
  height: 500px;
}

.photo {
  height: 100%;
  background-position: center center;
  background-size: cover;
}

.info {
  padding: 15px 20px;
}

.desc {
  margin: 5px 0 10px 0;
}

.text,
.links {
  width: 100%;
  max-width: 300px;
  margin: 0 auto;
}

.links {
  display: grid;
  grid-template-columns: repeat(2, max-content);
  gap: 20px;
  padding: 10px 0;
}

.more-button {
  background: transparent;
}

@media only screen and (min-width: 600px) {
  .highlighted {
    display: grid;
    grid-template-columns: repeat(6, 1fr);
    grid-template-areas: "info info info pic pic pic";
    align-items: center;
  }

  .photo {
    grid-area: pic;
  }

  .info {
    grid-area: info;
    display: flex;
    flex-direction: column;
    justify-content: center;
    height: 100%;
  }

  .text,
  .links {
    width: 90%;
    margin: 0 auto;
  }
}

@media only screen and (min-width: 800px) {
  .highlighted {
    display: grid;
    grid-template-columns: repeat(9, 1fr);
    grid-template-areas: "info info info info info pic pic pic pic";
    align-items: center;
    height: 470px;
  }
}
</style>