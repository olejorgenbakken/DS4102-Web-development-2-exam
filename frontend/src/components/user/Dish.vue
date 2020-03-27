<template>
  <article :id="theDish.id" class="dish" :dish="theDish.id">
    <section class="content">
      <router-link to="/">
        <aside>
          <span>x</span>
        </aside>
      </router-link>
      <figure class="photo">
        <img :src="theDish.photo" />
      </figure>
      <section class="dish-info">
        <header>
          <section class="dish-title">
            <label>Navn</label>
            <h1>{{theDish.name}}</h1>
          </section>
          <section class="price">
            <label>Pris</label>
            <h2>{{theDish.price}} kr</h2>
          </section>
        </header>
        <label>Beskrivelse</label>
        <p>{{theDish.description}}</p>
        <label>Ingredienser</label>
        <p v-for="ingredient in theDish.ingredients" :key="ingredient">{{ingredient}}</p>
        <button
          class="edit-button"
          @click="editDish"
          v-if="$route.params.pathMatch == '/admin'"
        >Rediger rett</button>
        <button class="buy-button" @click="addToCart">Legg til</button>
      </section>
    </section>
  </article>
</template>

<script>
import axios from "axios";
export default {
  name: "Dish",
  data() {
    return {
      theDish: {}
    };
  },
  created() {
    const webAPIUrl =
      "https://localhost:5001/api/dishes/" + this.$route.params.id;
    axios.get(webAPIUrl).then(response => {
      this.theDish = response.data;
    });
  },
  methods: {
    addToCart() {
      let webAPIUrl =
        "https://localhost:5001/api/dishes/" + this.$route.params.id;

      axios.get(webAPIUrl).then(response => {
        if (response.data.id == this.$el.getAttribute("dish")) {
          if (localStorage.getItem("order") == null) {
            let order = [response.data];
            localStorage.setItem("order", JSON.stringify(order));
          } else {
            let order = JSON.parse(localStorage.getItem("order"));
            order.push(response.data);
            localStorage.setItem("order", JSON.stringify(order));
          }
        }
      });
    }
  }
};
</script>

<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
.dish {
  position: fixed;
  overflow: auto;
  width: 100%;
  height: 100%;
  max-height: 100vh;
  background: white;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  margin: 0 auto;
  z-index: 1;
}

.content {
  background: var(--color);
  position: relative;
  color: black;
  width: 100%;
  padding-bottom: 80px;
  max-width: 700px;
  margin: 0 auto;
}

aside {
  width: 40px;
  height: 40px;
  display: flex;
  justify-content: center;
  align-items: center;
  background: white;
  color: var(--black);
  position: absolute;
  top: 20px;
  right: 20px;
  z-index: 2;
  border-radius: 30px;
  font-weight: 900;
  font-family: var(--subheading);
}

.photo {
  width: 100%;
  height: 200px;
}

.photo img {
  height: 100%;
  width: 100%;
  object-fit: cover;
}

.dish-info {
  padding: 20px;
}

.dish-info header {
  margin-bottom: 20px;
}

.dish-info header h1,
.dish-info header h2,
label {
  font-weight: 900;
  font-family: var(--subheading);
}

label {
  font-size: 0.9em;
}

.dish-info header h1 {
  font-size: 1.7em;
  margin-bottom: 10px;
}

.dish-info header h2 {
  font-size: 1.2em;
}

.dish-ingredients {
  display: grid;
  grid-template-columns: 120px 1fr;
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

.buy-button {
  right: 20px;
}

@media only screen and (min-width: 1000px) {
  .dish {
    padding-top: 100px;
  }

  .dish-info {
    padding: 20px 40px;
  }

  .dish-info header {
    display: grid;
    grid-template-columns: 1fr auto;
    gap: 40px;
  }
}
</style>