<template>
  <form class="upload">
    <section>
      <label>Navn</label>
      <input type="text" placeholder="Navn" id="name" />
    </section>
    <section>
      <label>Beskrivelse</label>
      <textarea placeholder="Beskrivelse"></textarea>
    </section>
    <section>
      <label>Type</label>
      <input type="text" placeholder="Type" />
    </section>
    <section>
      <label>Pris</label>
      <input type="text" placeholder="Pris" />
    </section>
    <section>
      <label>Kommer den i flere størrelser</label>
      <input type="text" placeholder="Flere størrelser?" />
    </section>
    <section>
      <label>Skal den fremheves?</label>
      <input type="text" placeholder="Fremhevet" />
    </section>
    <section>
      <label>Last opp bilde</label>
      <input id="upload-img" type="file" name="upload-img" />
    </section>
    <button @click="addNewDish">Last opp ny rett</button>
  </form>
</template>

<script>
import axios from "axios";

export default {
  name: "AddNewDish",
  data() {
    return {
      dish: [],
      newDish: {}
    };
  },
  methods: {
    addNewDish(e) {
      e.preventDefault();
      const webAPIUrl = "https://localhost:5001/api/dishes";

      let file = document.getElementById("upload-img");
      let imageData = new FormData();
      imageData.append("file", file.files[0]);

      this.newDish.Photo = file.files[0].name;

      console.log(this.newDish);

      axios.post(webAPIUrl, this.newDish).then(() => {
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
  width: 100%;
  max-width: 500px;
}

.upload > section {
  display: flex;
  flex-direction: column;
  margin-bottom: 20px;
}

input:not([type="file"]),
textarea {
  background: white;
  border: 1px solid grey;
  width: 100%;
  padding: 2px;
}

textarea {
  resize: vertical;
}

button {
  background: white;
  padding: 10px 25px;
  border-radius: 30px;
  font-size: 0.9em;
  font-weight: 600;
  font-family: var(--subheading);
  width: max-content;
}
</style>