<template>
  <article class="dish card">
    <section class="photo">
      <figure class="figure">
        <input type="file" name="upload-img" id="uploaded-pic" @change="previewPic" />
        <img :src="`https:/localhost:5001/images/${dish.photo}`" />
      </figure>
    </section>
    <section class="info">
      <section class="name">
        <label>Navn</label>
        <input v-model="dish.name" type="text" class="title" placeholder="Tittel" />
      </section>
      <section class="price">
        <label>Pris (kr)</label>
        <input type="number" v-model="dish.price" />
      </section>
      <section class="type">
        <label>Type</label>
        <select v-model="dish.type">
          <option v-for="type in dishTypes" :value="type.name" :key="type.id">{{type.name}}</option>
        </select>
      </section>
      <section class="ingredients">
        <label>Ingredienser</label>
        <select multiple v-model="dish.ingredients">
          <option
            v-for="ingredient in allIngredients"
            :key="ingredient"
            :value="ingredient"
          >{{ingredient}}</option>
        </select>
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
      <section class="desc">
        <label>Beskrivelse</label>
        <textarea v-model="dish.description" />
      </section>
      <button @click="deleteDish" class="del-btn">Slett</button>
    </section>
  </article>
</template>

<script>
import axios from "axios";

export default {
  name: "EditableDishItem",
  props: {
    id: Number
  },
  data() {
    return {
      dish: {
        ingredients: []
      },
      allIngredients: [],
      dishTypes: []
    };
  },
  created() {
    let dishesURL = `https://localhost:5001/dishes/${this.id}`;
    axios.get(dishesURL).then(response => {
      this.dish = response.data;
      this.dish.ingredients = JSON.parse(this.dish.ingredients);
    });

    let ingredientsURL = `https://localhost:5001/ingredients`;
    axios.get(ingredientsURL).then(response => {
      response.data.forEach(ingredient => {
        this.allIngredients.push(ingredient.name);
      });
    });

    let dishTypes = `https://localhost:5001/dishtypes`;
    axios.get(dishTypes).then(response => {
      this.dishTypes = response.data;
    });
  },
  methods: {
    addIngredient() {
      console.log(this.allIngredients);
    },
    deleteDish() {
      let dishesURL = `https://localhost:5001/dishes/${this.id}`;
      axios.delete(dishesURL);
    },
    previewPic() {
      let input = this.$el.querySelector("#uploaded-pic");
      this.dish.photo = input.files[0].name;
    },
    removeIng(e) {
      this.ingredients.forEach(ingredient => {
        if (ingredient == e.target.innerText) {
          const index = this.ingredients.indexOf(ingredient);
          if (index > -1) {
            this.ingredients.splice(index, 1);
          }
          e.target.remove();
        }
      });
    }
  },
  updated() {
    this.newDish = {
      name: this.dish.name,
      id: this.dish.id,
      ingredients: this.dish.ingredients,
      type: this.dish.type,
      price: this.dish.price,
      photo: this.dish.photo,
      description: this.dish.description,
      highlighted: this.dish.highlighted
    };
    this.newDish.price = parseInt(this.newDish.price);
    this.newDish.ingredients = JSON.stringify(this.newDish.ingredients);
    let input = this.$el.querySelector("#uploaded-pic");

    let dishUploadURL = `https://localhost:5001/dishes/upload`;

    if (input.files[0] != undefined && input.files[0].name == this.photo) {
      this.newDish.photo = input.files[0].name;
    } else if (
      input.files[0] != undefined &&
      input.files[0].name != this.newDish.photo
    ) {
      let imageData = new FormData();
      imageData.append("file", input.files[0]);
      axios
        .post(dishUploadURL, imageData, {
          headers: { "Content-type": "multiplart/form-data" }
        })
        .then(() => {
          this.newDish.photo = input.files[0].name;
          let dishURL = `https://localhost:5001/dishes/`;
          axios.put(dishURL, this.newDish);
        });
    } else {
      let dishURL = `https://localhost:5001/dishes/`;
      axios.put(dishURL, this.newDish);
    }
  }
};
</script>

<style scoped>
.dish {
  display: flex;
  flex-direction: column;
}

.photo {
  height: 200px;
}

.photo figure,
.photo input {
  height: 100%;
}

.photo input {
  position: absolute;
  width: 100%;
  opacity: 0;
  top: 0;
  left: 0;
  z-index: 1;
  cursor: pointer;
}

.info,
.highlighted {
  display: grid;
  grid-template-columns: 1fr;
  gap: 15px;
}

.info {
  padding: 20px;
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
</style>