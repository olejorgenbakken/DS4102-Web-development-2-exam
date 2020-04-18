<template>
  <form class="upload card">
    <header>
      <h3>Legg til rett</h3>
    </header>
    <section class="name">
      <label>Navn</label>
      <input type="text" placeholder="Navn" autocomplete="off" v-model="dish.name" />
    </section>
    <section class="price">
      <label>Pris</label>
      <input type="number" placeholder="99" autocomplete="off" v-model="dish.price" />
    </section>
    <section class="desc">
      <label>Beskrivelse</label>
      <textarea placeholder="Beskrivelse" autocomplete="off" v-model="dish.description"></textarea>
    </section>
    <section class="type">
      <label>Type</label>
      <select v-model="dish.type">
        <option disabled hidden selected>Velg type</option>
        <option v-for="type in dishTypes" :value="type" :key="type">{{ type }}</option>
      </select>
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
    <section class="photo">
      <label>Bilde</label>
      <figure class="figure">
        <input type="file" name="upload-img" id="new-pic" @change="showPicture" />
        <img :src="dish.photo" alt="Last opp et bilde" />
      </figure>
    </section>
    <button @click="addNewDish" class="submit-btn">Last opp ny rett</button>
  </form>
</template>

<script>
import axios from "axios";

export default {
  name: "AddNewDish",
  data() {
    return {
      dishTypes: ["Forrett", "Maki", "Sashimi", "Nigiri", "Vegetar", "Drikke"],
      dish: {}
    };
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
      let dishesURL = "https://localhost:5001/api/dishes";
      let imageData = new FormData();
      let input = this.$el.querySelector("#new-pic");
      imageData.append("file", input.files[0]);
      this.dish.price = parseInt(this.dish.price);
      this.dish.photo = input.files[0].name;
      axios.post(dishesURL, this.dish).then(() => {
        axios({
          method: "post",
          url: "https://localhost:5001/api/dishes/upload",
          data: imageData,
          config: { headers: { "Content-type": "multiplart/form-data" } }
        });
      });
    }
  }
};
</script>

<style scoped>
.upload {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
  padding: 20px;
  font-family: var(--paragraph);
}

.upload section {
  display: grid;
}

.price,
.name,
.desc,
.type,
.highlighted,
.input-highlighted,
.photo {
  display: grid;
  gap: 3px;
}

.price input,
.name input,
.desc textarea,
.type select,
.input-highlighted label {
  border: 1px solid black;
  background: #ffffff;
  border-radius: 5px;
  padding: 5px;
}

.desc textarea {
  resize: vertical;
  min-height: 40px;
  height: 50px;
  max-height: 130px;
}

.input-highlighted {
  grid-template-columns: repeat(2, auto);
  gap: 20px;
}

.input-highlighted label {
  display: flex;
  flex-direction: row;
  align-items: center;
  font-size: 0.8em;
}

.input-highlighted label p {
  margin-left: 10px;
}

.figure {
  position: relative;
  height: 30vh;
  min-height: 100px;
  max-height: 200px;
  overflow: hidden;
  border-radius: 10px;
}

.figure img {
  height: 100%;
  width: 100%;
  object-fit: cover;
}

.figure img::before {
  height: 100%;
  width: 100%;
  padding: 20px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  z-index: 2;
  color: black;
  background: whitesmoke;
}

#new-pic {
  position: absolute;
  width: 100%;
  height: 100%;
  opacity: 0;
  cursor: pointer;
}

.submit-btn {
  font-family: var(--heading);
  border-radius: 10px;
  padding: 10px 20px;
  background: var(--color);
  box-shadow: inset 10px 10px 100px var(--color),
    inset -10px -10px 100px var(--color);
  color: white;
  transition: 0.2s ease-in-out;
}

.submit-btn:hover {
  box-shadow: inset 10px 10px 100px var(--color),
    inset -10px -10px 100px var(--color);
}
</style>