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
        <input type="text" placeholder="Navn" autocomplete="off" v-model="dish.name" />
      </section>
      <section class="price">
        <label>Pris</label>
        <input type="number" placeholder="99" autocomplete="off" v-model="dish.price" />
      </section>
      <section class="type">
        <label>Type</label>
        <select v-model="dish.type">
          <option v-for="type in dishTypes" :value="type.name" :key="type.id">{{ type.name }}</option>
        </select>
      </section>
      <section class="desc">
        <label>Beskrivelse</label>
        <textarea placeholder="Beskrivelse" autocomplete="off" v-model="dish.description"></textarea>
      </section>
      <section class="highlighted">
        <label>Skal den fremheves?</label>
        <section class="input-highlighted">
          <label>
            <input type="radio" v-model="dish.highlighted" :value="true" />
            <p>Ja</p>
          </label>
          <label>
            <input type="radio" v-model="dish.highlighted" :value="false" />
            <p>Nei</p>
          </label>
        </section>
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
      <section class="selected-ingredients" v-if="dish.ingredients.length > 0">
        <label>Valgte ingredienser:</label>
        <section class="list">
          <p class="ingredient" v-for="n in dish.ingredients" :key="n" @click="removeIng">{{n}}</p>
        </section>
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
    removeIng(e) {
      this.dish.ingredients.forEach(ingredient => {
        if (ingredient == e.target.innerText) {
          const index = this.dish.ingredients.indexOf(ingredient);
          if (index > -1) {
            this.dish.ingredients.splice(index, 1);
          }
        }
      });
    },

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
  display: grid;
  grid-template-columns: 1fr;
  gap: 15px;
}

.upload {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: repeat(8, auto);
  grid-template-areas:
    "pic pic"
    "name name"
    "price price"
    "type type"
    "desc desc"
    "high high"
    "ing ing"
    "sel-ing sel-ing"
    "btn btn";
  gap: 15px;
  font-family: var(--paragraph);
  overflow: hidden;
  transition: 0.2s ease-in-out;
}

input,
textarea,
select {
  border: 1px solid black;
  background: #ffffff;
  border-radius: 2px;
  padding: 5px;
}

.name {
  grid-area: name;
  display: grid;
  gap: 3px 10px;
}

.price {
  display: grid;
  gap: 3px 10px;
  grid-area: price;
}

.type {
  display: grid;
  gap: 3px 10px;
  grid-area: type;
}

.desc {
  display: grid;
  gap: 3px 10px;
  grid-area: desc;
}

.desc textarea {
  resize: vertical;
  min-height: 40px;
  height: 100%;
  max-height: 130px;
}

.ingredients {
  display: grid;
  gap: 3px 10px;
  grid-area: ing;
}

.ingredients select {
  padding: 0;
  overflow: auto;
  height: 80px;
  transition: 0.2s ease-in-out;
}

select option {
  padding: 3px;
}

.selected-ingredients {
  grid-area: sel-ing;
}

.list {
  margin: -5px;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}

.ingredient {
  padding: 7px 15px;
  margin: 5px 5px;
  background: #fff;
  border: 1px solid rgba(0, 0, 0, 0.2);
  border-radius: 2px;
  cursor: pointer;
  height: max-content;
}

.highlighted {
  display: grid;
  gap: 3px 10px;
  grid-area: high;
}

.input-highlighted {
  display: grid;
  gap: 3px 10px;
  grid-template-columns: repeat(2, auto);
}

.input-highlighted label {
  display: flex;
  flex-direction: row;
  align-items: center;
  font-size: 0.8em;
  border: 1px solid black;
  background: #ffffff;
  border-radius: 2px;
  padding: 5px;
}

.input-highlighted label p {
  margin-left: 10px;
}

.photo {
  grid-area: pic;
  grid-template-rows: 15px 1fr;
  height: 30vh;
}

.photo figure {
  position: relative;
  height: 100%;
  overflow: hidden;
}

.photo figure img {
  height: 100%;
  width: 100%;
  object-fit: cover;
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  z-index: 2;
  color: black;
  background: #c0c0c0;
}

#new-pic {
  position: absolute;
  width: 100%;
  height: 100%;
  opacity: 0;
  cursor: pointer;
  padding: 20px;
}

.submit-btn {
  grid-area: btn;
  font-family: var(--heading);
  border-radius: 2px;
  padding: 10px 20px;
  background: black;
  color: white;
}

@media only screen and (min-width: 900px) {
  .upload {
    grid-template-columns: 300px repeat(2, 1fr);
    grid-template-rows: repeat(2, 50px) 100px 50px repeat(3, auto);
    grid-template-areas:
      "pic name name"
      "pic price type"
      "pic desc desc"
      "pic high high"
      "ing ing ing"
      "sel-ing sel-ing sel-ing"
      "btn btn btn";
  }

  .photo {
    height: 94%;
  }

  .desc textarea {
    resize: none;
    height: 86px;
  }

  .ingredients select {
    height: 120px;
  }
}
</style>