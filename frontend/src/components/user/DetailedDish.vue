<template>
  <article :id="theDish.id" class="detailed">
    <figure class="photo">
      <img :src="`https://localhost:5001/images/${theDish.photo}`" />
    </figure>
    <section class="info">
      <section class="title">
        <label>Navn</label>
        <h2>{{theDish.name}}</h2>
      </section>
      <section class="price">
        <label>Pris</label>
        <h3>{{theDish.price}} kr</h3>
      </section>
      <section>
        <label>Beskrivelse</label>
        <p>{{theDish.description}}</p>
      </section>
      <section>
        <label>Ingredienser</label>
        <p v-for="ingredient in JSON.parse(theDish.ingredients)" :key="ingredient">{{ingredient}}</p>
      </section>
      <BuyButton :id="theDish.id" :color="color"></BuyButton>
    </section>
  </article>
</template>

<script>
import axios from "axios";
import BuyButton from "./BuyButton";
export default {
  name: "DetailedDish",
  props: {
    color: String
  },
  components: {
    BuyButton
  },
  data() {
    return {
      theDish: {}
    };
  },
  watch: {
    $route() {
      let webAPIUrl = `https://localhost:5001/dishes/${this.$route.params.id}`;
      axios.get(webAPIUrl).then(response => {
        this.theDish = response.data;
      });
    }
  },
  mounted() {
    let webAPIUrl = `https://localhost:5001/dishes/${this.$route.params.id}`;
    axios.get(webAPIUrl).then(response => {
      this.theDish = response.data;
    });
  }
};
</script>

<style scoped>
.detailed {
  width: 100%;
  max-width: 1000px;
  margin: 0 auto;
  display: grid;
  grid-template-columns: 300px 1fr;
  grid-template-rows: 400px 1fr;
  grid-template-areas:
    "picture picture"
    "info info";
  gap: 10px 0;
}

.photo {
  grid-area: picture;
  overflow: hidden;
}

.photo img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.info {
  grid-area: info;
  width: 100%;
  max-width: 600px;
  margin: 0 auto;
  padding: 0 20px;
  display: grid;
  grid-template-columns: 1fr;
  gap: 10px;
}

.buy-button {
  color: white;
  width: 100%;
  max-width: 150px;
  padding: 10px;
  font-family: var(--heading);
  font-weight: 700;
  border-radius: 30px;
  transition: 0.3s ease-in-out;
}

@media only screen and (min-width: 800px) {
  .photo {
    border-radius: 20px;
  }
  .detailed {
    grid-template-areas:
      "picture info"
      "picture info";
    padding: 0 20px;
    gap: 0 10px;
  }

  .info {
    align-self: center;
    margin-left: 0;
  }
}
</style>