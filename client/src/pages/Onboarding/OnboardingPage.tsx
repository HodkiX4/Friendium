import Styles from "./onboarding.module.scss";
import type { ChangeEvent, FormEvent } from "react";
import { useRef, useState, useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import { FaCamera, FaPlus, FaTimes, FaUser } from "react-icons/fa";
import { useUserProfile } from "../../hooks/api/useUserProfile";
import { useAuthStore } from "../../store/authStore";
import { useToast } from "../../context/toastContext";

function OnboardingPage() {
  const navigate = useNavigate();
  const { user } = useAuthStore();
  const { showSuccess, showError } = useToast();
  const fileInputRef = useRef<HTMLInputElement | null>(null);
  const [avatarPreview, setAvatarPreview] = useState<string | null>(null);
  const [hobbyInput, setHobbyInput] = useState<string>("");
  const [hobbies, setHobbies] = useState<string[]>([]);
  const [isSubmitting, setIsSubmitting] = useState(false);
  const { updateUserProfile } = useUserProfile();

  useEffect(() => {
    return () => {
      if (avatarPreview) {
        URL.revokeObjectURL(avatarPreview);
      }
    };
  }, [avatarPreview]);

  const handleAvatarClick = () => fileInputRef.current?.click();

  const handleAvatarChange = (e: ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files && e.target.files[0];
    if (!file) return;

    if (avatarPreview) {
      URL.revokeObjectURL(avatarPreview);
    }

    const url = URL.createObjectURL(file);
    setAvatarPreview(url);
  };

  const addHobby = () => {
    const value = hobbyInput.trim();
    if (!value) return;
    setHobbies((prev) => [...prev, value]);
    setHobbyInput("");
  };

  const removeHobby = (idx: number) => {
    setHobbies((prev) => prev.filter((_, i) => i !== idx));
  };

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (!user) {
      showError("User not authenticated");
      return;
    }

    setIsSubmitting(true);

    try {
      const formData = new FormData(e.currentTarget);

      const payload: any = {
        bio: (formData.get("bio") as string) || undefined,
        city: (formData.get("city") as string) || undefined,
        country: (formData.get("country") as string) || undefined,
        interests: hobbies.length > 0 ? hobbies : undefined,
      };

      if (avatarPreview) {
        payload.avatarUrl = avatarPreview;
      }

      Object.keys(payload).forEach(
        (key) => payload[key] === undefined && delete payload[key],
      );

      await updateUserProfile(user.id, payload);
      showSuccess("Profile updated successfully!");
      navigate("/protected/home");
    } catch (error) {
      showError("Failed to update profile. Please try again.");
      console.error("Error updating profile:", error);
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <div className={Styles.profileForm}>
      <h3>Complete Your Profile</h3>
      <span>
        Tell us more about yourself to help you find the perfect friends
      </span>
      <form onSubmit={handleSubmit}>
        <div className={Styles.avatarRow}>
          <div
            className={Styles.avatarWrap}
            onClick={handleAvatarClick}
            role="button"
            aria-label="Upload avatar"
          >
            {avatarPreview ? (
              <img
                src={avatarPreview}
                alt="Avatar preview"
                className={Styles.avatarImg}
              />
            ) : (
              <div className={Styles.avatarPlaceholder}>
                <FaUser />
              </div>
            )}
            <div className={Styles.cameraOverlay}>
              <FaCamera />
            </div>
            <input
              ref={fileInputRef}
              type="file"
              accept="image/*"
              onChange={handleAvatarChange}
              className={Styles.hiddenFile}
            />
          </div>
        </div>

        <textarea
          name="bio"
          placeholder="Short biography"
          rows={3}
          className={Styles.textarea}
        ></textarea>

        <div className={Styles.row}>
          <input type="text" name="country" placeholder="Country" />
          <input type="text" name="city" placeholder="City" />
        </div>

        <label className={Styles.hobbiesLabel}>Hobbies</label>
        <div className={Styles.hobbiesRow}>
          <input
            value={hobbyInput}
            onChange={(e) => setHobbyInput(e.target.value)}
            placeholder="Add a hobby"
          />
          <button
            type="button"
            className={Styles.addBtn}
            onClick={addHobby}
            aria-label="Add hobby"
          >
            <FaPlus />
          </button>
        </div>

        <ul className={Styles.hobbyList}>
          {hobbies.map((h, idx) => (
            <li key={idx} className={Styles.hobbyItem}>
              <span>{h}</span>
              <button
                type="button"
                className={Styles.removeHobby}
                onClick={() => removeHobby(idx)}
                aria-label={`Remove ${h}`}
              >
                <FaTimes />
              </button>
            </li>
          ))}
        </ul>

        <div className={Styles.actions}>
          <Link to="/protected/home" className={Styles.skipLink}>
            Skip for now
          </Link>
          <button
            type="submit"
            className={Styles.submitBtn}
            disabled={isSubmitting}
          >
            {isSubmitting ? "Saving..." : "Complete setup"}
          </button>
        </div>
      </form>
    </div>
  );
}

export default OnboardingPage;
