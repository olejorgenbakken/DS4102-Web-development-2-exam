<template>
  <form class="new-dish card">
    <header>
      <h2>Legg til rett</h2>
    </header>
    <section class="upload">
      <section class="photo">
        <label>Bilde</label>
        <figure class="figure">
          <input type="file" name="upload-img" id="new-pic" @input="showPicture" />
          <img :src="dish.photo" alt="Last opp et bilde" />
        </figure>
      </section>
      <section class="name">
        <label>Navn</label>
        <input class="title" type="text" placeholder="Navn" autocomplete="off" v-model="dish.name" />
      </section>
      <section class="price">
        <label>Pris (kr)</label>
        <input type="number" placeholder="99" autocomplete="off" v-model="dish.price" />
      </section>
      <section class="type">
        <label>Type</label>
        <select v-model="dish.type">
          <option :value="null" selected="selected" disabled>Velg type</option>
          <option v-for="type in dishTypes" :value="type.name" :key="type.id">{{ type.name }}</option>
        </select>
      </section>
      <section class="desc">
        <label>Beskrivelse</label>
        <textarea placeholder="Beskrivelse" autocomplete="off" v-model="dish.description"></textarea>
      </section>
      <section class="highlighted">
        <label class="header">Skal den fremheves?</label>
        <label class="input">
          <input type="radio" v-model="dish.highlighted" :value="true" />
          Ja
        </label>
        <label class="input">
          <input type="radio" v-model="dish.highlighted" :value="false" />
          Nei
        </label>
      </section>
      <section class="ingredients">
        <label>Ingredienser</label>
        <select multiple v-model="dish.ingredients">
          <option
            v-for="ingredient in ingredients"
            :key="ingredient"
            :value="ingredient"
          >{{ingredient}}</option>
        </select>
      </section>
      <button @click="addNewDish" class="submit-btn">Last opp ny rett</button>
    </section>
  </form>
</template>

<script>
import axios from "axios";

export default {
  name: "AddNewDish",
  data() {
    return {
      dishTypes: [],
      ingredients: [],
      dish: {
        type: null,
        ingredients: []
      }
    };
  },
  created() {
    let ingredientsURL = `https://localhost:5001/ingredients`;
    axios.get(ingredientsURL).then(response => {
      response.data.forEach(ingredient => {
        this.ingredients.push(ingredient.name);
      });

      this.ingredient.sort((a, b) => {
        return a.localeCompare(b);
      });
    });

    let dishListURL = `https://localhost:5001/dishtypes`;
    axios.get(dishListURL).then(response => {
      this.dishTypes = response.data;
    });
  },
  methods: {
    showPicture() {
      let input = this.$el.querySelector("#new-pic");
      if (input.files && input.files[0]) {
        let reader = new FileReader();
        reader.onload = e => {
          this.dish.photo = e.target.result;
        };
        reader.readAsDataURL(input.files[0]);
      }
    },
    addNewDish(e) {
      e.preventDefault();
      let dishesURL = "https://localhost:5001/dishes";
      let imageData = new FormData();
      let input = this.$el.querySelector("#new-pic");
      imageData.append("file", input.files[0]);
      this.dish.price = parseInt(this.dish.price);
      this.dish.photo = input.files[0].name;
      this.dish.ingredients = JSON.stringify(this.dish.ingredients);
      axios.post(dishesURL, this.dish).then(() => {
        axios({
          method: "post",
          url: "https://localhost:5001/dishes/upload",
          data: imageData,
          config: { headers: { "Content-type": "multiplart/form-data" } }
        }).then(() => {
          this.dish = { ingredients: [] };
        });
      });
    }
  }
};
</script>

<style scoped>
.new-dish {
  padding: 20px;
  display: flex;
  flex-direction: column;
}

.new-dish header {
  margin-bottom: 10px;
}

.upload,
.highlighted {
  display: grid;
}

.upload {
  grid-template-columns: 1fr;
  gap: 14px 20px;
}

.photo {
  position: relative;
  height: 200px;
  overflow: hidden;
}

.photo figure,
.photo input {
  height: 100%;
}

.photo input {
  position: absolute;
  opacity: 0;
  top: 0;
  left: 0;
}

.highlighted {
  gap: 0 10px;
  grid-template-columns: repeat(2, 1fr);
}

.highlighted .header {
  grid-column: 1 / span 2;
}

label.input {
  display: flex;
  flex-direction: row;
  align-items: center;
  padding: 5px;
}

label.input input {
  margin-right: 5px;
}

@media only screen and (min-width: 800px) {
  .upload {
    grid-template-columns: repeat(5, 1fr);
    grid-template-areas:
      "pic pic name name name"
      "pic pic price type type"
      "pic pic desc desc desc"
      "pic pic highlighted highlighted highlighted"
      "ingredients ingredients ingredients ingredients ingredients"
      "submit-btn submit-btn submit-btn submit-btn submit-btn";
  }

  .photo {
    height: 100%;
    grid-area: pic;
    grid-row: 1 / span 4;
  }

  .name {
    grid-area: name;
  }

  .price {
    grid-area: price;
  }

  .type {
    grid-area: type;
  }

  .desc {
    grid-area: desc;
  }

  .highlighted {
    grid-area: highlighted;
  }

  .ingredients {
    grid-area: ingredients;
  }

  .submit-btn {
    grid-area: submit-btn;
  }
}
</style>